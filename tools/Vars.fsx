[<AutoOpen>]
module Vars

#load "CompilerHelper.fsx"

// Properties
let buildDir = "build"
let srcDir = "src"
let docsDir = "docs"
let docsBuildDir = Path.Combine(docsDir, "build")
let testDir = "test"
let testBuildDir = Path.Combine(testDir, "build")
let version = "0.11.0"
let projectName = "ComposableExtensions"
let projectUrl = "http://jbtule.github.io/ComposableExtensions"
let gitHubProjectUrl = "https://github.com/jbtule/ComposableExtensions"
let githubCloneUrl = gitHubProjectUrl + ".git"
let githubSourceUrl = gitHubProjectUrl + "/blob/stable/src/NET45"
let nugetUrl = "http://nuget.org/packages/" + projectName
let title = "FSharp Composable Extension Functions"
let description = "Inline composable fsharp functions around BCL static methods."
let authors = ["Jay Tuley"]
//let guid = "68ebe4ce-c63b-478d-a084-c5e36b3e8091"
let root = System.Environment.CurrentDirectory
let projectTargets = [ NET45; NET40; NET35; PORTABLE_47 ]
let projectFSharpVersion = CompilerHelper.FS30
