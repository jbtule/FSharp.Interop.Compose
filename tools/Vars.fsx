[<AutoOpen>]
module Vars

open System.IO

#load "CompilerHelper.fsx"

// Properties
let buildDir = "build"
let srcDir = "src"
let docsDir = "docs"
let docsBuildDir = Path.Combine(docsDir, "www")
let testDir = "test"
let testBuildDir = Path.Combine(testDir, "build")
let nugetToolPath = Path.Combine("tools", "packages", "NuGet.CommandLine", "tools" , "NuGet.exe")
let version = "1.14.0"
let projectName = "FSharp.Interop.Compose"
let projectUrl = "http://jbtule.github.io/FSharp.Interop.Compose"
let gitHubProjectUrl = "https://github.com/jbtule/FSharp.Interop.Compose"
let githubCloneUrl = gitHubProjectUrl + ".git"
let githubSourceUrl = gitHubProjectUrl + "/blob/stable"
let nugetUrl = "http://nuget.org/packages/" + projectName
let title = "FSharp.Interop.Compose Extension Functions"
let description = "Inline composable fsharp functions around BCL static methods. Supports .net 3.5 through .net Standard"
let authors = ["Jay Tuley"]
//let guid = "68ebe4ce-c63b-478d-a084-c5e36b3e8091"
let root = System.Environment.CurrentDirectory
let projectTargets = [ NET45; NET40; NET35; PORTABLE_47; PORTABLE_259; NETSTD_2_0 ]
