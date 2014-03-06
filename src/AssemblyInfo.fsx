namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp Composable Extension Functions")>]
[<assembly: AssemblyDescriptionAttribute("Inline composable fsharp functions around BCL static methods.")>]
[<assembly: AssemblyProductAttribute("ComposableExtensions")>]
[<assembly: AssemblyVersionAttribute("0.10.3")>]
[<assembly: AssemblyFileVersionAttribute("0.10.3")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.10.3"
