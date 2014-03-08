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

#I "packages/FSharp.Compiler.Service/lib/net40/"
#r "FSharp.Compiler.Service.dll"
#I "packages/RazorEngine/lib/net40/"
#I "packages/FSharp.Formatting/lib/net40/"
#r "FSharp.MetadataFormat.dll"
#r "FSharp.Literate.dll"

open System.IO
open FSharp.MetadataFormat
open FSharp.Literate

#load "Vars.fsx"

let testRoot = Path.Combine(root, "docs", "build", "output")

let projInfo =
  [ "project-author",  authors |> String.concat ", "
    "project-summary", description
    "project-github",  gitHubProjectUrl
    "project-nuget", nugetUrl
    "project-name", projectName
    "root" , projectUrl ]

let dll = Path.Combine(root, buildDir, "NET45", projectName + ".dll")

let outputDir = Path.Combine(docsBuildDir, "output")

Directory.CreateDirectory(outputDir)

let content = Directory.GetFiles(Path.Combine(docsDir, "content"))
let outputContentDir = Path.Combine(outputDir, "content")

Directory.CreateDirectory(outputContentDir)

for file in content do
    File.Copy(file, Path.Combine(outputContentDir, Path.GetFileName(file)))


let options = "--reference:\"" + dll + "\""


let template =Path.Combine(docsDir, "templates", "docpage.cshtml")
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



//Api-docs

let refDir = Path.Combine(outputDir, "reference")

Directory.CreateDirectory(refDir)
MetadataFormat.Generate(dll, refDir,
    [ Path.Combine(docsDir, "templates");
        Path.Combine(docsDir, "templates", "reference") ],
        parameters = projInfo,
        sourceRepo = githubSourceUrl,
        sourceFolder = root)
