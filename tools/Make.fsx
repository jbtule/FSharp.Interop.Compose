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
#r "packages/FSharp.Compiler.Service/lib/net40/FSharp.Compiler.Service.dll"

open Fake
open Fake.AssemblyInfoFile
open System.IO
open Microsoft.FSharp.Compiler.SimpleSourceCodeServices
open Tools

// Properties
let buildDir = "./build/"
let srcDir = "./src/"
let publishDir = "./publish/"
let testDir = "./test/"
let testBuildDir = Path.Combine(testDir,"build/")
let version = "0.7.1"
let projectName = "ComposableExtensions"
let projectUrl = "https://github.com/jbtule/ComposableExtensions"
let title = "FSharp Composable Extension Methods"
let description = "Automated composable F# functions for .net BCL extension methods."
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

    let files = Directory.GetDirectories(srcDir) 
                    |> Seq.collect (fun d -> Directory.GetFiles(d,"*.fsx"))
                    |> Seq.toList

    let compilerOpts = ["fsc.exe"; "-o"; output; "-a"; Path.Combine(srcDir, "AssemblyInfo.fsx")] @ files


    let errors,errorCode = scs.Compile(compilerOpts |> List.toArray)
    if errorCode = 0 then
        trace "build success"
    else
        let exs = errors |> Seq.map (fun e -> System.Exception(e.ToString()))
        raise (System.AggregateException(exs))
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
    
"Test"
    ==> "Deploy"

// start build
RunTargetOrDefault "Test"