namespace System
open System.Reflection
open System.Runtime.InteropServices

[<assembly: AssemblyTitleAttribute("FSharp Composable Extension Methods")>]
[<assembly: AssemblyDescriptionAttribute("Automated composable F# functions for .net BCL extension methods.")>]
[<assembly: GuidAttribute("68ebe4ce-c63b-478d-a084-c5e36b3e8091")>]
[<assembly: AssemblyProductAttribute("ComposableExtensions")>]
[<assembly: AssemblyVersionAttribute("0.5")>]
[<assembly: AssemblyFileVersionAttribute("0.5")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.5"
