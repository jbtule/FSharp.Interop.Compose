namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp Composable Extension Functions")>]
[<assembly: AssemblyDescriptionAttribute("NET45: Inline composable fsharp functions around BCL static methods.")>]
[<assembly: AssemblyProductAttribute("ComposableExtensions")>]
[<assembly: AssemblyVersionAttribute("0.11.0")>]
[<assembly: AssemblyFileVersionAttribute("0.11.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.11.0"
