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

  let queryHeader = header + br + br + "#load \"../../../helpers/Quotations.fsx\""

  for target in projectTargets do
    tracefn "Generating Source for %A" target

    let sysfull = systemTargetInfo target projectFSharpVersion
                      |> systemDllsResolver

    let targetDir = Path.Combine(srcDir, sprintf "%A" target)

    Directory.CreateDirectory targetDir |> ignore

    let generateWrapper  = Generate.writeWrappers header targetDir sysfull
    let generateQueryWrapper = Generate.writeWrappers queryHeader targetDir sysfull

    generateWrapper "System.Linq" "Enumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]
    generateWrapper "System.Linq" "ParallelEnumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]

    match target with
      | NET35 -> ()
      | _ -> generateQueryWrapper "System.Linq" "Queryable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]

    let stringMethodFilters = [
                                IdentifyMethods.matchesSignature Static "Join" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                                IdentifyMethods.matchesName Static "IsNullOrWhiteSpace"
                                IdentifyMethods.matchesName Static "IsNullOrEmpty"
                                IdentifyMethods.matchesSignature Instance "Replace" ["System.String";"System.String"]
                                IdentifyMethods.matchesSignature Instance "Split" ["System.Char"]
                                IdentifyMethods.matchesSignature Instance "Split" ["System.Char[]"]
                                IdentifyMethods.matchesNames Instance ["StartsWith";"Contains";"EndsWith"; "Trim"; "TrimStart"; "TrimEnd" ; "ToLower" ; "ToUpper"; "PadRight";"PadLeft"]
                                ]

    generateWrapper "System" "String" Reorder.noChange stringMethodFilters

    let fileMethodFilters = [
                              IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                              IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>";"System.Text.Encoding"]
                              IdentifyMethods.matchesName Static "AppendAllLines"
                              ]

    let reorderForFile = Reorder.moveTypeToTheEnd "System.Collections.Generic.IEnumerable`1<System.String>"
    generateWrapper "System.IO" "File" reorderForFile fileMethodFilters


    generateWrapper "System.Collections.Generic" "Comparer" Reorder.noChange [IdentifyMethods.matchesName Static "Create"]
    generateWrapper "System.Collections.Generic" "EqualityComparer" Reorder.noChange [IdentifyMethods.matchesName Static "Default"]


    CreateFSharpAssemblyInfo (Path.Combine(targetDir, "AssemblyInfo.fsx"))
          [Attribute.Title title
           Attribute.Description (sprintf "%A: %s" target description)
           //Attribute.Guid guid
           Attribute.Product projectName
           Attribute.Version version
           Attribute.FileVersion version
           ]
)


Target "Build" (fun _ ->

  for target in projectTargets do
    tracefn "Build targeting %A" target
    let targetDir = Path.Combine(srcDir, sprintf "%A" target)
    let targetBuildDir = Path.Combine(buildDir, sprintf "%A" target)
    Directory.CreateDirectory targetBuildDir |> ignore

    let output = Path.Combine(targetBuildDir, projectName + ".dll")
    let xml = Path.Combine(targetBuildDir, projectName + ".xml")

    let files = Directory.GetDirectories(targetDir)
                    |> Seq.collect (fun d -> Directory.GetFiles(d,"*.fsx"))
                    |> Seq.toList

    let compilerOpts =
          ["-o"; output; "--doc:"+ xml; "--debug:pdbonly" ; "-a"; Path.Combine(targetDir, "AssemblyInfo.fsx")]
          @ files

    fscTargeting (systemTargetInfo target projectFSharpVersion) compilerOpts
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

  for target in projectTargets do

    let runningTarget =
      match target with
        | NET35 -> NET35
        | _ -> NET45

    tracefn "Build Tests targeting %A" target
    let targetBuildDir = Path.Combine(buildDir, sprintf "%A" target)
    let targetTestBuildDir = Path.Combine(testBuildDir, sprintf "%A" target)
    Directory.CreateDirectory targetTestBuildDir |> ignore

    let testDll = Path.Combine(targetTestBuildDir,"Test.dll")
    let files = Directory.GetFiles(testDir,"*.fsx") |> Seq.toList

    let refdlls =
      [
        Path.Combine(targetBuildDir, "ComposableExtensions.dll")
        "./tools/packages/xunit/lib/net20/xunit.dll"
        systemDllsResolver ([], runningTarget, projectFSharpVersion) |> Seq.head
      ]
      @ match target with
          | NET35 ->
            [
              "./tools/packages/FsUnit.xUnit/Lib/net20/NHamcrest.dll"
              "./tools/packages/FsUnit.xUnit/Lib/net20/FsUnit.CustomMatchers.dll"
              "./tools/packages/FsUnit.xUnit/Lib/net20/FsUnit.Xunit.dll"
            ]
          | _ ->
            [
              "./tools/packages/FsUnit.xUnit/Lib/net40/NHamcrest.dll"
              "./tools/packages/FsUnit.xUnit/Lib/net40/FsUnit.CustomMatchers.dll"
              "./tools/packages/FsUnit.xUnit/Lib/net40/FsUnit.Xunit.dll"
            ]

    for f in refdlls do
       FileHelper.CopyFile targetTestBuildDir f

    File.Copy("./tools/fsharp-redirect.config",testDll+".config")

    let compilerOpts =
        (refdlls |> List.map (fun d -> sprintf "--reference:%s" d))
        @ [sprintf "--define:TEST_%A" target;"-o";  testDll; "-a"]
        @ files

    fscTargeting (systemTargetInfo runningTarget projectFSharpVersion) compilerOpts
)

Target "Test" (fun _ ->

  for target in projectTargets do
    tracefn "Running Tests targeting %A" target
    let targetTestBuildDir = Path.Combine(testBuildDir, sprintf "%A" target)
    let testDll = Path.Combine(targetTestBuildDir,"Test.dll")

    let runner =
      match target with
        | NET35 -> Path.Combine("tools","packages", "xunit.runners", "tools", "xunit.console.exe")
        | _ -> Path.Combine("tools","packages", "xunit.runners", "tools", "xunit.console.clr4.exe")

    !! (testDll)
         |> xUnit (fun p -> {p with OutputDir = targetTestBuildDir; ToolPath =  runner })
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

"Build"
    ==> "BuildOnly"

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
