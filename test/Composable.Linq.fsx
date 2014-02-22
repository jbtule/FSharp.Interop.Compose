namespace Test.Composable.Linq

#load "includes.fsx"


open Xunit
open FsUnit.Xunit
open Composable.Linq

module Enumerable =
    
    [<Fact>]
    let reverse () =
        seq { 1 .. 5 } |> Enumerable.reverse |> Seq.toList |> should equal [5;4;3;2;1]
    
    [<Fact>]
    let defaultIfEmpty () =
        Seq.empty<int> |> Enumerable.defaultIfEmpty |> Seq.toList |> should equal [0]
        
    [<Fact>]
    let orderByDescending () =
        seq { 'a' .. 'c' } |> Enumerable.orderByDescending (fun c -> c) |> Seq.toList |> should equal ['c';'b';'a']
    