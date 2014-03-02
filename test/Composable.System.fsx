namespace Test.Composable.System

#load "includes.fsx"

open Xunit
open FsUnit.Xunit
open Composable.System

module String =

    [<Fact>]
    let padLeft () =
        "hello" |> String.padLeft 6 |> should equal " hello"

    [<Fact>]
    let padRight () =
        "hello" |> String.padRight 6 |> should equal "hello "

    [<Fact>]
    let trimStart () =
        " hello " |> String.trimStart [|' '|] |> should equal "hello "

    [<Fact>]
    let trimEnd () =
        " hello " |> String.trimEnd [|' '|] |> should equal " hello"

    [<Fact>]
    let trim () =
        " hello " |> String.trim |> should equal "hello"
        
    [<Fact>]
    let startsWith () =
        ["One";"Two";"Three"]
           |> Seq.filter (String.startsWith "T")
           |> Seq.toList
           |> should equal ["Two";"Three"]

    [<Fact>]
    let join () =
        ["1";"2";"3"] |> String.join " " |> should equal "1 2 3"

    [<Fact>]
    let isNullOrWhitespace () =
        ["1";"";"2";"  "; "3"; null; "4"]
           |> Seq.filter (not << String.isNullOrWhiteSpace)
           |> Seq.toList
           |> should equal ["1";"2";"3";"4"]

    [<Fact>]
    let isNullOrEmpty() =
        ["1";"";"2";"  "; "3"; null; "4"]
           |> Seq.filter (not << String.isNullOrEmpty)
           |> Seq.toList
           |> should equal ["1";"2";"  ";"3";"4"]
