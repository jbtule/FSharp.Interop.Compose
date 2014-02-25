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

let dll = Path.Combine(root, buildDir, projectName + ".dll")

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
        sourceFolder = Path.Combine(root, srcDir))