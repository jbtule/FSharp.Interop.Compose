namespace Test.FSharp.Interop.Compose.Text.RegularExpressions

#load "includes.fsx"

open Xunit
open FsUnit.Xunit
open FSharp.Interop.Compose.Text.RegularExpressions

module Regex =

    [<Fact>]
    let isMatch () =
        ["Who"; "What"; "Where"; "When"; "Why"; "How"]
          |> List.filter (Regex.isMatch @"Wh.*")
          |> should equal ["Who"; "What"; "Where"; "When"; "Why"]

    [<Fact>]
    let ``match`` () =
        let m = "One car red car blue car"
                  |> Regex.``match`` @"(\w+)\s+(car)"
        m.Success |> should be True
        m.Groups
          |> Seq.cast<System.Text.RegularExpressions.Group>
          |> Seq.map (sprintf "%O")
          |> Seq.toList
          |> should equal ["One car"; "One"; "car"]

    [<Fact>]
    let matches () =
        "Who writes these notes?"
            |> Regex.matches @"\b\w+es\b"
            |> Seq.cast<System.Text.RegularExpressions.Match>
            |> Seq.map (fun m -> m.Value)
            |> Seq.toList
            |> should equal ["writes";"notes"]

    [<Fact>]
    let replace () =
        "This is   text with   far  too   much   whitespace."
            |> Regex.replace @"\s+" (fun m-> " ")
            |> should equal "This is text with far too much whitespace."

    [<Fact>]
    let split () =
        "123ABCDE456FGHIJKL789MNOPQ012"
            |> Regex.split @"\d+"
            |> Array.toList
            |> should equal [""; "ABCDE"; "FGHIJKL"; "MNOPQ"; ""]
