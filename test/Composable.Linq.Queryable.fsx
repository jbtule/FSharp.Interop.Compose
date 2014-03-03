namespace Test.Composable.Linq

#load "includes.fsx"

open Xunit
open FsUnit.Xunit
open Composable.Linq

module ``Queryable Basic Tests`` =

    [<Fact>]
    let where () =
        [1;4;5;6;7;8;1;4;5;6;7;8]
            |> Queryable.asQueryable
            |> Queryable.where <@ (fun i -> i < 5) @>
            |> Seq.toList
            |> should equal [1;4;1;4]
