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
#load "CompilerHelper.fsx"

#I "packages/FAKE/tools"
#r "FakeLib.dll"

open Fake
open Fake.AssemblyInfoFile
open System.IO
open Tools

#load "Vars.fsx"

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
    CleanDir docsBuildDir
)

Target "Generate" (fun _ ->

   let br = System.Environment.NewLine
   let header  = sprintf "// Generated with %s (%s) %s" projectName version projectUrl

   let queryHeader = header + br + br + "#load \"../../helpers/Quotations.fsx\""
   let sysMap = CompilerHelper.systemDllsTargeting projectTarget
                      |> Seq.map (fun p -> Path.GetFileName p, p)
                      |> Map.ofSeq
   let resolvePath libName =
        match (sysMap |> Map.tryFind libName) with | Some(p) -> p | _ -> ""

   let generateWrapper libName  = Generate.writeWrappers header srcDir (resolvePath libName)
   let generateQueryWrapper libName = Generate.writeWrappers queryHeader srcDir (resolvePath libName)

   let coreAsm = "System.Core.dll"
   let mscorlibAsm = "mscorlib.dll"

   generateWrapper coreAsm "System.Linq" "Enumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]
   generateWrapper coreAsm "System.Linq" "ParallelEnumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]

   generateQueryWrapper coreAsm "System.Linq" "Queryable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]

   let stringMethodFilters = [IdentifyMethods.matchesSignature Static "Join" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                              IdentifyMethods.matchesName Static "IsNullOrWhiteSpace"
                              IdentifyMethods.matchesName Static "IsNullOrEmpty"
                              IdentifyMethods.matchesSignature Instance "Replace" ["System.String";"System.String"]
                              IdentifyMethods.matchesSignature Instance "Split" ["System.Char"]
                              IdentifyMethods.matchesSignature Instance "Split" ["System.Char[]"]
                              IdentifyMethods.matchesNames Instance ["StartsWith";"Contains";"EndsWith"; "Trim"; "TrimStart"; "TrimEnd" ; "ToLower" ; "ToUpper"; "PadRight";"PadLeft"]
                              ]
   generateWrapper mscorlibAsm "System" "String" Reorder.noChange stringMethodFilters

   let fileMethodFilters = [IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                            IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>";"System.Text.Encoding"]
                            IdentifyMethods.matchesName Static "AppendAllLines"
                            ]

   let reorderForFile = Reorder.moveTypeToTheEnd "System.Collections.Generic.IEnumerable`1<System.String>"
   generateWrapper mscorlibAsm "System.IO" "File" reorderForFile fileMethodFilters


   generateWrapper mscorlibAsm "System.Collections.Generic" "Comparer" Reorder.noChange [IdentifyMethods.matchesName Static "Create"]
   generateWrapper mscorlibAsm "System.Collections.Generic" "EqualityComparer" Reorder.noChange [IdentifyMethods.matchesName Static "Default"]


   CreateFSharpAssemblyInfo (Path.Combine(srcDir, "AssemblyInfo.fsx"))
        [Attribute.Title title
         Attribute.Description description
         //Attribute.Guid guid
         Attribute.Product projectName
         Attribute.Version version
         Attribute.FileVersion version
         ]
)


Target "Build" (fun _ ->

    let output = Path.Combine(buildDir, projectName + ".dll")
    let xml = Path.Combine(buildDir, projectName + ".xml")

    let files = Directory.GetDirectories(srcDir)
                    |> Seq.collect (fun d -> Directory.GetFiles(d,"*.fsx"))
                    |> Seq.toList
      
    let compilerOpts = 
          ["-o"; output; "--doc:"+ xml; "-a"; Path.Combine(srcDir, "AssemblyInfo.fsx")]
          @ files

    fscTargeting projectTarget compilerOpts
)

Target "Docs" (fun _ ->

    //run doc script
    FSIHelper.runBuildScriptAt root true "tools/Docs.fsx" [] [] |> ignore

    let docOutput = Path.Combine(docsBuildDir, "output")
    let localRepo = Path.Combine(docsBuildDir,"gh-pages");

    //Copy to gh-pages branch
    Git.Repository.clone "" githubCloneUrl localRepo
    Git.Branches.checkoutBranch localRepo "gh-pages"
    CopyRecursive docOutput localRepo true |> printfn "%A"
)

Target "BuildTest" (fun _ ->

    let testDll = Path.Combine(testBuildDir,"Test.dll")
    let files = Directory.GetFiles(testDir,"*.fsx") |> Seq.toList

    let refdlls =
        [ "./build/ComposableExtensions.dll"
          "./tools/packages/xunit/lib/net20/xunit.dll"
          "./tools/packages/FsUnit.xUnit/Lib/net40/NHamcrest.dll"
          "./tools/packages/FsUnit.xUnit/Lib/net40/FsUnit.CustomMatchers.dll"
          "./tools/packages/FsUnit.xUnit/Lib/net40/FsUnit.Xunit.dll"
          "./tools/packages/FSharp.Core.3/lib/net40/FSharp.Core.dll"
          ]

    for f in refdlls do
       FileHelper.CopyFile testBuildDir f

    File.Copy("./tools/fsharp-redirect.config",testDll+".config")

    let compilerOpts = 
        ["-o";  testDll; "-a"]
        @ files

    fscTargeting CompilerHelper.NET40 compilerOpts
) 

Target "Test" (fun _ ->

    let testDll = Path.Combine(testBuildDir,"Test.dll")

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
    ==> "BuildTest"
    ==> "Test"

"CleanDocs"
    ==> "Docs"

"Test"
    ==> "Docs"
    ==> "Deploy"

// start build
RunTargetOrDefault "Test"
