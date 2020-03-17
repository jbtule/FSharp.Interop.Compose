[<AutoOpen>]
module Vars


#r "System.Xml.Linq"

open System.IO
open System
open System.Xml.Linq
open System.Xml.XPath

#load "CompilerHelper.fsx"

let configuration = Environment.GetEnvironmentVariable("configuration")
                    |> Option.ofObj
                    |> Option.defaultValue "Debug"
// Properties
let buildDir = Path.Combine("proj", "bin")
let srcDir = "src"
let docsDir = "docs-src"
let docsBuildDir = "docs"
let testDir = "test"
let testBuildDir = Path.Combine(testDir, "bin")
let nugetToolPath = Path.Combine("tools", "packages", "NuGet.CommandLine", "tools" , "NuGet.exe")
let versionPrefix = "Version.props" 
                        |> File.ReadAllText 
                        |> XDocument.Parse
                        |> (fun x -> x.XPathEvaluate("//VersionPrefix/text()"))
                        |> (fun x-> x :?> seq<obj>)
                        |> Seq.exactlyOne
                        |> sprintf "%A"

let projectName = "FSharp.Interop.Compose"
let projectUrl = "http://jbtule.github.io/FSharp.Interop.Compose"
let gitHubProjectUrl = "https://github.com/jbtule/FSharp.Interop.Compose"

let licenceUrl = sprintf "%s/%s" gitHubProjectUrl "blob/master/LICENSE.txt"
let requireLicence = true

let githubCloneUrl = gitHubProjectUrl + ".git"
let githubSourceUrl = gitHubProjectUrl + "/blob/stable"
let nugetUrl = "http://nuget.org/packages/" + projectName
let title = "FSharp.Interop.Compose Extension Functions"
let description = "Inline composable fsharp functions around BCL static methods. Supports .net 3.5 through .net Standard"

let projectTags = [
                    "fsharp"
                    "compose"
                    "composition"
                    "curry"
                    "BCL"
                  ]

let authors = ["Jay Tuley"]

let copyright = authors 
                    |> String.concat " " 
                    |> sprintf "Copyright 2014-2018 %s"

//let guid = "68ebe4ce-c63b-478d-a084-c5e36b3e8091"
let root = System.Environment.CurrentDirectory
let projectTargets = [ NET45; NET40; NET35; PORTABLE_47; PORTABLE_259; NETSTD_2_0 ]
