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

namespace Tools
#r "packages/Mono.Cecil/lib/net40/Mono.Cecil.dll"
#r "packages/FSharp.Compiler.Service/lib/net40/FSharp.Compiler.Service.dll"

open System.Reflection
open System.IO
open Mono.Cecil

module Reformat =

    let private keywordSet = Set(Microsoft.FSharp.Compiler.Lexhelp.Keywords.keywordNames)

    let camelCase (x:string) = System.String.Join("", System.Char.ToLower(x.[0])::(x |> Seq.skip 1 |> Seq.toList))
                    
    let slimGenericName x = System.Text.RegularExpressions.Regex.Replace(x, "`\d+", "")
    
    let private wrapKeywords (s:string) = if keywordSet.Contains(s) then "``" + s + "``" else s
    
    let testForFunc (x:TypeReference) =
        x.FullName.StartsWith("System.Func")
                            
    let rec typeNameFixer usesFsharpFunc (x:TypeReference) =
        let typeNameFix = typeNameFixer usesFsharpFunc
        if x.IsGenericInstance then
            let g = x :?> GenericInstanceType
            if usesFsharpFunc && testForFunc x then
                (g.GenericArguments |> Seq.map typeNameFix |> String.concat "->")
            else
                sprintf "%s.%s<%s>" x.Namespace (slimGenericName x.Name) (g.GenericArguments |> Seq.map typeNameFix |> String.concat ", ")
        elif x.IsGenericParameter then
            sprintf "'%s" x.Name
        else
            sprintf "%s.%s" x.Namespace x.Name
    let parameterFixer (specifyAllTypes:bool) (x:ParameterDefinition) =
        if testForFunc x.ParameterType || specifyAllTypes then
            sprintf "(%s:%s)" (wrapKeywords x.Name) (typeNameFixer true x.ParameterType)
        else
            wrapKeywords x.Name
    
    let csharpCastFunc (x:ParameterDefinition) =
        if testForFunc x.ParameterType then
            let castType = typeNameFixer false x.ParameterType
            sprintf "%s(%s)" castType x.Name
        else
            x.Name
    
    let namespaceComposable (x:string) =
        if x.StartsWith("System") && x <> "System" then
            x.Replace("System", "Composable")
        else
            sprintf "Composable.%s" x
    
    let methodWrapper (x:MethodDefinition) =
        let paramCnt = x.Parameters |> Seq.length
        let specifyAllTypes = 
            (x.DeclaringType.Methods
                 |> Seq.filter (fun m-> m.Name = x.Name && (m.Parameters |> Seq.length) = paramCnt)
                 |> Seq.length) > 1
        let fsharpName = camelCase x.Name
        let parameterFix = parameterFixer specifyAllTypes
        let fsharpParams = (x.Parameters |> Seq.map parameterFix |> String.concat " ")
        let csharpParams = (x.Parameters |> Seq.map csharpCastFunc |> String.concat ", ")
        sprintf "let inline %s %s = %s.%s(%s)" fsharpName fsharpParams x.DeclaringType.FullName x.Name csharpParams

module Reorder =
    let noChange (m:MethodDefinition) : seq<ParameterDefinition> = upcast m.Parameters

    let private equivalentTypes (t1:TypeReference) (t2:TypeReference) =
        let replaceName (t:GenericInstanceType) = 
             t.GenericArguments |> Seq.fold (fun (acc:string) gp -> acc.Replace(gp.Name,"_")) t.FullName
        if t1.IsGenericInstance && t2.IsGenericInstance then
            (downcast t1 |> replaceName) = (downcast t2 |> replaceName )
        else
            t1.FullName = t2.FullName    

    let private endsWithNumber = System.Text.RegularExpressions.Regex(@"^.*\d+$")


    let private identifyReorder2 (ps:ParameterDefinition seq) =
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

    let private reorderExtParameters (ps:ParameterDefinition seq) =
         if (ps |> Seq.length) > 1 && identifyReorder2 ps then
             Seq.append (ps |> Seq.skip 2) (ps |> Seq.take 2)
         else
             Seq.append (ps |> Seq.skip 1) (ps |> Seq.take 1)

    let extensionMethodReorder (m:MethodDefinition) = reorderExtParameters m.Parameters

module IdentifyMethods =

    let isPublicStaticMethod (x:MethodDefinition) = x.IsStatic && x.IsPublic

    let private hasExtensionMember (x:IMemberDefinition) = 
        x.HasCustomAttributes && x.CustomAttributes 
            |> Seq.exists (fun a -> a.AttributeType.FullName = "System.Runtime.CompilerServices.ExtensionAttribute")

    let isExtensionMethod (x:MethodDefinition) = hasExtensionMember x
    
    let matchesSigniture (name:string) (argTypes:string seq) (m:MethodDefinition) =
        let nameMatch =  m.Name = name
        let paramTypes = (m.Parameters |> Seq.map (fun p -> p.ParameterType.FullName))
        nameMatch && System.Linq.Enumerable.SequenceEqual(paramTypes, argTypes)

module Generate =

    let writeWrappers (header:string) (srcDir:string) (asm:string) (namesp:string) (typeName:string) (orderedParameters:MethodDefinition->seq<ParameterDefinition>) (methodSelectors:(MethodDefinition->bool) list) =
        let asmDef = AssemblyDefinition.ReadAssembly((Assembly.Load(asm)).Location)
        let methods = asmDef.MainModule.Types
                        |> Seq.filter (fun t -> t.IsPublic)
                        |> Seq.filter (fun t -> t.Namespace.StartsWith(namesp))
                        |> Seq.filter (fun t -> t.Name.StartsWith(typeName))
                        |> Seq.collect (fun t -> t.Methods |> Seq.filter IdentifyMethods.isPublicStaticMethod)

        let chosenMethods = methodSelectors |> Seq.fold (fun acc pred -> methods |> Seq.filter pred |> Seq.append acc) Seq.empty |> Seq.distinct

        let removedMostOverloads = chosenMethods
                                    |> Seq.groupBy (fun m -> (m.Name,m.Parameters |> Seq.length))
                                    |> Seq.filter (fun (k,g) -> g |> Seq.length = 1)
                                    |> Seq.collect (fun (k,g) -> g)
            
        let foldHighLowLists (minL:MethodDefinition list,maxL:MethodDefinition list) (minC:int, maxC:int, g:MethodDefinition seq) =
            let high = g |> Seq.find (fun m-> (m.Parameters |> Seq.length) = maxC)
            let low = g |> Seq.find (fun m-> (m.Parameters |> Seq.length) = minC)
            if maxC = minC then
                (low::minL, maxL)
            else
                (low::minL, high::maxL)
        
        let main,full = removedMostOverloads
                            |> Seq.groupBy (fun m -> m.Name)
                            |> Seq.map (fun (k,g) -> (g |> Seq.map (fun m->Seq.length m.Parameters), g))
                            |> Seq.map (fun (c,g) -> (c |> Seq.min, c |> Seq.max, g))
                            |> Seq.fold foldHighLowLists (List.empty, List.empty)
        
        
        let list = [true,main;false,full]
        let nsp = Reformat.namespaceComposable namesp
        for (isMain, mlist) in list do
            if not (Seq.isEmpty mlist) then 
                let path = Path.Combine(srcDir, nsp)
                Directory.CreateDirectory(path) |> ignore
                use writer = System.IO.File.AppendText(Path.Combine(path, typeName+".fsx"))
                if isMain then
                     writer.WriteLine(header)
                     writer.WriteLine()
                     writer.WriteLine(sprintf "module %s.%s" nsp typeName)
                else
                     writer.WriteLine()
                     writer.WriteLine("module Full =")
                for m in mlist |> Seq.sortBy (fun x->x.Name) do
                    if not isMain then
                        writer.Write(String.replicate 4 " ")
                    writer.WriteLine(Reformat.methodWrapper m)