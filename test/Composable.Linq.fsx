namespace Test.Composable.Linq

#load "includes.fsx"

open Xunit
open FsUnit.Xunit
open Composable.Linq

module Enumerable =
    
    [<Fact>]
    let aggregate () =
        seq { 1 .. 5 } |> Enumerable.aggregate (fun acc i -> acc + i) |> should equal 15 
 
    [<Fact>]
    let ``all of 1-5 is less than 6`` () =
        seq { 1 .. 5 } |> Enumerable.all (fun i -> i < 6) |> should be True 

    [<Fact>]
    let ``all of 1-5 is not greater than 3`` () =
        seq { 1 .. 5 } |> Enumerable.all (fun i -> i > 3) |> should be False

    [<Fact>]
    let ``any means not empty`` () =
        [] |> Enumerable.any|> should be False
        [1;2;3] |> Enumerable.any|> should be True 

    [<Fact>]
    let ``full any of 1-5 is greater than 3`` () =
        seq { 1 .. 5 } |> Enumerable.Full.any (fun i -> i > 3) |> should be True 

    [<Fact>]
    let ``full any of 1-5 is not greater than 6`` () =
        seq { 1 .. 5 } |> Enumerable.Full.any (fun i -> i > 6) |> should be False 

    [<Fact>]
    let cast () =
       let nonGeneric = new System.Collections.ArrayList([|1;2;3|]);
       let generic = nonGeneric |> Enumerable.cast<int>
       for i in generic do
            i |> should be ofExactType<int>

    [<Fact>]
    let concat () =
        (seq { 1 .. 3 }, seq{ 4 .. 6 })
            ||> Enumerable.concat
            |> Seq.toList |> should equal [1;2;3;4;5;6]

    [<Fact>]
    let contains () =
        seq { 1 .. 10 }
            |> Enumerable.contains 5 |> should be True
        seq { 1 .. 10 }
            |> Enumerable.contains 11 |> should be False

    [<Fact>]
    let Count () =
        seq { 0 .. 9 }
            |> Enumerable.count |> should equal 10

    [<Fact>]
    let defaultIfEmpty () =
        Seq.empty<int> |> Enumerable.defaultIfEmpty |> Seq.toList |> should equal [0]
        
    [<Fact>]
    let distinct () =
        [1;1;2;1;1;3;3;4;5;5;5]
            |> Enumerable.distinct
            |> Seq.toList |> should equal [1;2;3;4;5]

    [<Fact>]
    let elementAt () =
        seq { 1 .. 9 }
            |> Enumerable.elementAt 4 |> should equal 5

    [<Fact>]
    let elementAtOrDefault () =
        seq { 1 .. 9 }
            |> Enumerable.elementAtOrDefault 10 |> should equal 0

    [<Fact>]
    let except () =
        seq { 1 .. 7 }
            |> Enumerable.except (seq { 2 .. 5 })
            |> Seq.toList |> should equal [1;6;7]

    [<Fact>]
    let first () =
        seq {1 .. 7}
            |> Enumerable.first |> should equal 1

    [<Fact>]
    let firstOrDefault () =
        Seq.empty<int>
            |> Enumerable.firstOrDefault |> should equal 0

    [<Fact>]
    let groupBy () =
        seq { 1..9 }
            |> Enumerable.groupBy (fun i -> i % 2)
            |> Seq.find (fun g-> g.Key = 0)
            |> Seq.toList |> should equal [2;4;6;8]
   
    [<Fact>]
    let orderByDescending () =
        seq { 'a' .. 'c' } |> Enumerable.orderByDescending (fun c -> c) |> Seq.toList |> should equal ['c';'b';'a']

    [<Fact>]
    let reverse () =
        seq { 1 .. 5 } |> Enumerable.reverse |> Seq.toList |> should equal [5;4;3;2;1]

    [<Fact>]
    let thenBy () =
        let p1 = (seq { 'a' .. 'c' }, seq { 1 .. 3}) ||> Seq.zip 
        let p2 = (seq { 'x' .. 'z' }, seq { 1 .. 3}) ||> Seq.zip 
        Seq.append p1 p2 
            |> Enumerable.orderByDescending (fun (_,n)->n) 
            |> Enumerable.thenBy (fun(a,_)->a)
            |> Seq.toList
            |> should equal [('c',3);('z',3);('b',2);('y',2);('a',1);('x',1)]