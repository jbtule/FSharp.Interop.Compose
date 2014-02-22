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

    [<Fact>]
    let thenBy () =
        let p1 = (seq { 'a' .. 'c' }, seq { 1 .. 3}) ||> Seq.zip 
        let p2 = (seq { 'x' .. 'z' }, seq { 1 .. 3}) ||> Seq.zip 
        Seq.append p1 p2 
            |> Enumerable.orderByDescending (fun (_,n)->n) 
            |> Enumerable.thenBy (fun(a,_)->a)
            |> Seq.toList
            |> should equal [('c',3);('z',3);('b',2);('y',2);('a',1);('x',1)]