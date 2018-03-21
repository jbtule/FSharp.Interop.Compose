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

module DocHelper

#I "packages/FSharp.Compiler.Service/lib/net45/"
#r "FSharp.Compiler.Service.dll"
#I "packages/FSharpVSPowerTools.Core/lib/net45"
#r "FSharpVSPowerTools.Core.dll"
#I "packages/FSharp.Formatting/lib/net40/"
#r "RazorEngine.dll"
#r "FSharp.MetadataFormat.dll"
#r "FSharp.Literate.dll"
#r "FSharp.CodeFormat.dll"

open System.IO
open FSharp.MetadataFormat
open FSharp.Literate

#load "Vars.fsx"

let generateDocs () =
  printfn "Generating Docs..."
  let projInfo =
    [ "project-author",  authors |> String.concat ", "
      "project-summary", description
      "project-github",  gitHubProjectUrl
      "project-nuget", nugetUrl
      "project-name", projectName
      "root" , projectUrl ]

  let dll = Path.Combine(root, buildDir, configuration, "netstandard2.0", projectName + ".dll")

  let outputDir = docsBuildDir

  Directory.CreateDirectory(outputDir) |> ignore

  let content = Directory.GetFiles(Path.Combine(docsDir, "content"))
  let outputContentDir = Path.Combine(outputDir, "content")

  Directory.CreateDirectory(outputContentDir)  |> ignore

  for file in content do
      File.Copy(file, Path.Combine(outputContentDir, Path.GetFileName(file)))


  let options = "--reference:\"" + dll + "\""


  let template = "docpage.cshtml"
  let templateDirs = [ Path.Combine(docsDir, "templates");
          Path.Combine(docsDir, "templates", "reference") ]

  Literate.ProcessMarkdown(
      Path.Combine(root,"Readme.md"),
      templateFile = template,
      output = Path.Combine(outputDir, "index.html"),
      replacements = projInfo,
      compilerOptions = options,
      layoutRoots = templateDirs,
      includeSource = true )

  Literate.ProcessMarkdown(
      Path.Combine(root, "docs", "why.md"),
      templateFile = template,
      output = Path.Combine(outputDir, "why.html"),
      replacements = projInfo,
      compilerOptions = options,
      layoutRoots = templateDirs,
      includeSource = true )



  //Api-docs
  let refDir = Path.Combine(outputDir, "reference")

  Directory.CreateDirectory(refDir) |> ignore
  MetadataFormat.Generate(dll, refDir,
      [ Path.Combine(docsDir, "templates");
          Path.Combine(docsDir, "templates", "reference") ],
          parameters = projInfo,
          sourceRepo = githubSourceUrl,
          sourceFolder = root)
  printfn "Finished Generating Docs."
  ()
