namespace Test.Composable.System

#load "includes.fsx"

open Xunit
open FsUnit.Xunit
open Composable.System

module String =

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