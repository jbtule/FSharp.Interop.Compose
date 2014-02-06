// Copyright 2014 Jay Tuley <jay+code@tuley.name>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#I "buildpackages/FAKE/tools"
#r "buildpackages/FAKE/tools/FakeLib.dll"
#r "buildpackages/FSharp.Compiler.Service/lib/net40/FSharp.Compiler.Service.dll"
#r "buildpackages/Mono.Cecil/lib/net40/Mono.Cecil.dll"

open Fake
open Fake.AssemblyInfoFile
open System.Reflection
open Mono.Cecil
open System.IO
open Microsoft.FSharp.Compiler.SimpleSourceCodeServices
open Microsoft.FSharp.Compiler.Lexhelp

// Properties
let buildDir = "./build/"
let genDir = "./gensrc/"
let publishDir = "./publish/"
let version = "0.5"
let projectName = "ComposableExtensions"
let projectUrl = "https://github.com/jbtule/ComposableExtensions"
let title = "FSharp Composable Extension Methods"
let description = "Automated composable F# functions for .net BCL extension methods."
let authors = ["Jay Tuley"]
let guid = "68ebe4ce-c63b-478d-a084-c5e36b3e8091"

// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
    CleanDir genDir
)

type methInfo = { namesp : string; name : string; fullmethodname : string; paramct : int; wrapper : string }

Target "Generate" (fun _ ->


    let asms = ["System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                ]
                
    let asmDef (x:string) = AssemblyDefinition.ReadAssembly((Assembly.Load(x)).Location)

    let isPublicStatic (x:MethodDefinition) = x.IsStatic && x.IsPublic

    let hasExtensionMember (x:IMemberDefinition) = 
        x.HasCustomAttributes && x.CustomAttributes 
            |> Seq.exists (fun a -> a.AttributeType.FullName = "System.Runtime.CompilerServices.ExtensionAttribute")

    let camelCase (x:string) = System.String.Join("", System.Char.ToLower(x.[0])::(x |> Seq.skip 1 |> Seq.toList))
                                                           
    let join (s:string) (ss:string seq) : string = System.String.Join(s, ss)

    let equivalentTypes (t1:TypeReference) (t2:TypeReference) =
        let replaceName (t:GenericInstanceType) = 
             t.GenericArguments |> Seq.fold (fun (acc:string) gp -> acc.Replace(gp.Name,"_")) t.FullName
        if t1.IsGenericInstance && t2.IsGenericInstance then
            (downcast t1 |> replaceName) = (downcast t2 |> replaceName )
        else
            t1.FullName = t2.FullName

    let endsWithNumber = System.Text.RegularExpressions.Regex(@"^.*\d+$")

    let identifyReorder2 (ps:ParameterDefinition seq) =
        let p1 = (ps |> Seq.nth 0)
        let p2 = (ps |> Seq.nth 1)

        if equivalentTypes p1.ParameterType p2.ParameterType then
            true
        elif endsWithNumber.IsMatch(p1.Name) && endsWithNumber.IsMatch(p2.Name) then
            true
        elif p2.Name = "inner" then
            true
        else
            false

    let reorderParameters (ps:ParameterDefinition seq) =
         if (ps |> Seq.length) > 1 && identifyReorder2 ps then
             Seq.append (ps |> Seq.skip 2) (ps |> Seq.take 2)
         else
             Seq.append (ps |> Seq.skip 1) (ps |> Seq.take 1)

    let keywordSet = Set(Microsoft.FSharp.Compiler.Lexhelp.Keywords.keywordNames)

    let wrapKeywords (s:string) = if keywordSet.Contains(s) then "``" + s + "``" else s


    let srcInfo (m:MethodDefinition) =  let fullMethodName = m.DeclaringType.FullName + "." + m.Name
                                        let paramNames (ps:ParameterDefinition seq) = 
                                            ps |> Seq.map (fun p -> wrapKeywords p.Name)
                                        let reorderListParams = reorderParameters >> paramNames >> join " "
                                        let passParams = paramNames >> join ","
                                        {
                                            namesp = m.DeclaringType.Namespace.Replace("System","Composable");
                                            name = if m.DeclaringType.Name <> "Extensions" then
                                                      m.DeclaringType.Name.Replace("Extensions","")
                                                   else
                                                      m.DeclaringType.Name
                                            fullmethodname = fullMethodName;
                                            paramct = Seq.length m.Parameters;
                                            wrapper = sprintf "let %s %s = %s.%s(%s)"
                                                        (camelCase m.Name)
                                                        (m.Parameters |> reorderListParams)
                                                        m.DeclaringType.FullName
                                                        m.Name
                                                        (m.Parameters |> passParams)
                                        }


    let maxAndMin (x:methInfo seq) =
        let cnts = x |> Seq.map (fun y -> y.paramct)
        let max =  cnts |> Seq.max
        let min = cnts |> Seq.min
        x |> Seq.choose (fun y -> if y.paramct = min then
                                      Some("",y)
                                  elif y.paramct = max then
                                      Some("Full", y)
                                  else 
                                    None)

    let groups = asms
                   |> Seq.collect (fun a -> (asmDef a).MainModule.Types)
                   |> Seq.filter (fun t -> t.IsPublic)
                   |> Seq.filter hasExtensionMember
                   |> Seq.collect (fun t -> t.Methods
                                           |> Seq.filter isPublicStatic
                                           |> Seq.filter hasExtensionMember)
                   |> Seq.map srcInfo
                   |> Seq.groupBy (fun x -> x.fullmethodname, x.paramct)
                   |> Seq.filter (fun (_,y) -> Seq.length y = 1) //Filter out overloaded extensions
                   |> Seq.collect(fun (_,y) -> y) //flatten list
                   |> Seq.groupBy (fun x-> x.fullmethodname) //Group by name  
                   |> Seq.collect (fun (_,y) -> y |> maxAndMin) //flatten and mark the highest and lowest paramct
                   |> Seq.sortBy (fun (m, x) -> x.fullmethodname)    
                   |> Seq.groupBy (fun (m,x)-> x.namesp,x.name,m)    
      
    let IsFullModule (x:string) = x = "Full"

    for (nsp, n, m), x in groups do
        let path = Path.Combine(genDir, nsp)
        Directory.CreateDirectory(path) |> ignore
        use writer = System.IO.File.AppendText(Path.Combine(path,n+".fsx"))
        if IsFullModule m then
            writer.WriteLine()
            writer.WriteLine("module Full =")
        else
           writer.WriteLine(sprintf "// Generated with %s (%s) %s" projectName version projectUrl)
           writer.WriteLine()
           writer.WriteLine("module " + nsp + "." + n)
        for _,y in x do
            writer.WriteLine()
            if IsFullModule m then
                writer.Write("    ")
            writer.WriteLine(y.wrapper)
    
    CreateFSharpAssemblyInfo (Path.Combine(genDir, "AssemblyInfo.fsx"))
        [Attribute.Title title
         Attribute.Description description
         Attribute.Guid guid
         Attribute.Product projectName
         Attribute.Version version
         Attribute.FileVersion version]
)


Target "Default" (fun _ ->
    
    let scs = SimpleSourceCodeServices()
    let output = Path.Combine(buildDir, projectName + ".dll")

    let files = Directory.GetDirectories(genDir) 
                    |> Seq.collect (fun d -> Directory.GetFiles(d,"*.fsx"))
                    |> Seq.toList

    let compilerOpts = ["fsc.exe"; "-o"; output; "-a"; Path.Combine(genDir, "AssemblyInfo.fsx")] @ files


    let errors,errorCode = scs.Compile(compilerOpts |> List.toArray)
    if errorCode = 0 then
        trace "build success"
    else
        let exs = errors |> Seq.map (fun e -> System.Exception(e.ToString()))
        raise (System.AggregateException(exs))
)


Target "CreatePackage" (fun _ ->

    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = projectName                           
            OutputPath = publishDir
            WorkingDir = publishDir
            Description = description
            Version = version
            Publish = false })
            (Path.Combine(publishDir, projectName + ".nuspec"))
)


// Dependencies
"Clean" 
  ==> "Generate"
    ==> "Default"
      ==> "CreatePackage"

// start build
RunTargetOrDefault "Default"