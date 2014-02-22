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

#load "Generate.fsx"

#I "packages/FAKE/tools"
#r "packages/FAKE/tools/FakeLib.dll"
#I "packages/FSharp.Compiler.Service/lib/net40/"
#r "FSharp.Compiler.Service.dll"
#r "packages/Microsoft.AspNet.Razor/lib/net40/System.Web.Razor.dll"
#I "packages/RazorEngine/lib/net40/"
#I "packages/FSharp.Formatting/lib/net40/"
#r "FSharp.MetadataFormat.dll"

open Fake
open Fake.AssemblyInfoFile
open System.IO
open Microsoft.FSharp.Compiler.SimpleSourceCodeServices
open FSharp.MetadataFormat
open Tools

// Properties
let root = System.Environment.CurrentDirectory
let buildDir = "./build/"
let srcDir = "./src/"
let docsDir = "./docs/"
let publishDir = "./publish/"
let testDir = "./test/"
let testBuildDir = Path.Combine(testDir,"build/")
let version = "0.7.2"
let projectName = "ComposableExtensions"
let projectUrl = "https://github.com/jbtule/ComposableExtensions"
let title = "FSharp Composable Extension Functions"
let description = "Inline composable fsharp functions around BCL static methods."
let authors = ["Jay Tuley"]
let guid = "68ebe4ce-c63b-478d-a084-c5e36b3e8091"

// Targets
Target "CleanSrc" (fun _ ->
    CleanDir srcDir
)

Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "CleanTest" (fun _ ->
    CleanDir testBuildDir
)

Target "CleanDocs" (fun _ ->
    CleanDir  docsDir
)

Target "Generate" (fun _ ->
   
   let header  = sprintf "// Generated with %s (%s) %s" projectName version projectUrl
   let generateWrapper = Generate.writeWrappers header srcDir
    
   let coreAsm = "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
   let mscorlibAsm = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"

   generateWrapper coreAsm "System.Linq" "Enumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]
   generateWrapper coreAsm "System.Linq" "ParallelEnumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]
   
   let stringMethodFilters = [IdentifyMethods.matchesSignature "Join" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                              IdentifyMethods.matchesName "IsNullOrWhiteSpace"
                              IdentifyMethods.matchesName "IsNullOrEmpty"
                              ]
   generateWrapper mscorlibAsm "System" "String" Reorder.noChange stringMethodFilters
    
   let fileMethodFilters = [IdentifyMethods.matchesSignature "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]]
   generateWrapper mscorlibAsm "System.IO" "File" Reorder.noChange  fileMethodFilters
   
   CreateFSharpAssemblyInfo (Path.Combine(srcDir, "AssemblyInfo.fsx"))
        [Attribute.Title title
         Attribute.Description description
         Attribute.Guid guid
         Attribute.Product projectName
         Attribute.Version version
         Attribute.FileVersion version]
)


Target "Build" (fun _ ->
    
    let scs = SimpleSourceCodeServices()
    let output = Path.Combine(buildDir, projectName + ".dll")
    let xml = Path.Combine(buildDir, projectName + ".xml")

    let files = Directory.GetDirectories(srcDir) 
                    |> Seq.collect (fun d -> Directory.GetFiles(d,"*.fsx"))
                    |> Seq.toList

    let compilerOpts = ["fsc.exe"; "-o"; output; "--doc:"+ xml; "-a"; Path.Combine(srcDir, "AssemblyInfo.fsx")] @ files


    let errors,errorCode = scs.Compile(compilerOpts |> List.toArray)
    if errorCode = 0 then
        trace "build success"
    else
        let exs = errors |> Seq.map (fun e -> System.Exception(e.ToString()))
        raise (System.AggregateException(exs))
)

Target "Docs" (fun _ ->
    let output = Path.Combine(root, buildDir, projectName + ".dll")
    
    let projInfo =
      [ "page-author",  authors |> Seq.head
        "page-description", description
        "github-link",  projectUrl
        "project-name", projectName
        "root", root ]
    
    MetadataFormat.Generate(output, docsDir,
        [ Path.Combine("tools", "packages","FSharp.Formatting", "templates", "reference") ],
            parameters = projInfo,
            sourceRepo = "https://github.com/jbtule/ComposableExtension/tree/master",
            sourceFolder = Path.Combine(root, srcDir))
)


Target "Test" (fun _ ->

    let testDll = Path.Combine(testBuildDir,"Test.dll")
    let scs = SimpleSourceCodeServices()
    let files = Directory.GetFiles(testDir,"*.fsx") |> Seq.toList
    
    let refdlls = 
        [ "./build/ComposableExtensions.dll"
          "./tools/packages/xunit/lib/net20/xunit.dll"
          "./tools/packages/FsUnit.xUnit/Lib/net40/NHamcrest.dll"
          "./tools/packages/FsUnit.xUnit/Lib/net40/FsUnit.CustomMatchers.dll"
          "./tools/packages/FsUnit.xUnit/Lib/net40/FsUnit.Xunit.dll"
          ] 
    
    for f in refdlls do 
       FileHelper.CopyFile testBuildDir f
  
    
    let compilerOpts = ["fsc.exe"; "-o";  testDll; "-a"] @ files
    
    let errors,errorCode = scs.Compile(compilerOpts |> List.toArray)
    if errorCode = 0 then
        trace "test build success"
    else
        let exs = errors |> Seq.map (fun e -> System.Exception(e.ToString()))
        raise (System.AggregateException(exs))
    
    let runner = Path.Combine("tools","packages", "xunit.runners", "tools", "xunit.console.clr4.exe") 
    
    !! (testDll)
         |> xUnit (fun p -> {p with OutputDir = testDir; ToolPath =  runner })
)

Target "BuildOnly" (fun _ ->
    ()
)

Target "Deploy" (fun _ ->

    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = projectName                           
            OutputPath = buildDir
            WorkingDir = buildDir
            Description = description
            Version = version
            Publish = false })
            (projectName + ".nuspec")
)


// Dependencies
"CleanSrc"
    ==> "Generate"

"Clean" 
    =?> ("Generate", not (hasBuildParam "BuildOnly"))
    ==> "Build"
    
"CleanTest"
    ==> "Build"
    ==> "Test"
    
"CleanDocs"
    ==> "Docs"
    
"Test"
    ==> "Docs"
    ==> "Deploy"

// start build
RunTargetOrDefault "Test"