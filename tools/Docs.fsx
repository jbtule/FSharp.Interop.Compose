#I "packages/FSharp.Compiler.Service/lib/net40/"
#r "FSharp.Compiler.Service.dll"
#r "packages/Microsoft.AspNet.Razor/lib/net40/System.Web.Razor.dll"
#I "packages/RazorEngine/lib/net40/"
#I "packages/FSharp.Formatting/lib/net40/"
#r "FSharp.MetadataFormat.dll"

open System.IO
open FSharp.MetadataFormat

#load "Vars.fsx"


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