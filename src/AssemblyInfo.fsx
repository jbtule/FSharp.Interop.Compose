namespace System
open System.Reflection
open System.Runtime.InteropServices

[<assembly: AssemblyTitleAttribute("FSharp Composable Extension Functions")>]
[<assembly: AssemblyDescriptionAttribute("Inline composable fsharp functions around BCL static methods.")>]
[<assembly: GuidAttribute("68ebe4ce-c63b-478d-a084-c5e36b3e8091")>]
[<assembly: AssemblyProductAttribute("ComposableExtensions")>]
[<assembly: AssemblyVersionAttribute("0.8.1")>]
[<assembly: AssemblyFileVersionAttribute("0.8.1")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.8.1"
