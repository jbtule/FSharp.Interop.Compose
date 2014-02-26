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
        seq { 1 .. 9 }
            |> Enumerable.groupBy (fun i -> i % 2)
            |> Seq.find (fun g-> g.Key = 0)
            |> Seq.toList |> should equal [2;4;6;8]
            
    [<Fact>]
    let groupJoin () =
        (["One",1;"Two",2;"Three",3],[1;1;1;2;2])
            ||> Enumerable.groupJoin (fun (_,o)->o) (fun i->i) (fun (o,_) ic -> (o, Seq.length ic))
            |> Seq.toList |> should equal ["One",3;"Two",2;"Three",0]
             
    [<Fact>]
    let intersect () =
        (seq { 1 .. 7 }, seq { 5 .. 9 })
            ||> Enumerable.intersect
            |> Seq.toList |> should equal [5;6;7]
            
    [<Fact>]
    let join () =
        (["One",1;"Two",2;"Three",3],["Ichi",1;"Ni",2;"San",3])
            ||> Enumerable.join (fun (_,o)->o) (fun (_,i)->i) (fun (o,_) (i,_) -> (o, i))
            |> Seq.toList |> should equal ["One","Ichi";"Two","Ni";"Three","San"]
   
    [<Fact>]
    let last () =
        seq { 1 .. 9 } |> Enumerable.last |> should equal 9
    
    [<Fact>] 
    let lastOrDefault () =
        Seq.empty<int> |> Enumerable.lastOrDefault |> should equal 0
    
    [<Fact>]    
    let longCount () =
        seq { 0 .. 9 } |> Enumerable.longCount |> should equal 10L
   
    [<Fact>]
    let ofType () =
       let list = System.Collections.ArrayList()
       list.Add(1)
       list.Add("2")
       list.Add(3)
       list.Add("4")
       list
           |> Enumerable.ofType<int>
           |> Seq.toList |> should equal [1;3]
   
    [<Fact>]
    let orderBy () =
        ['t';'a';'n'] |> Enumerable.orderBy (fun c -> c) |> Seq.toList |> should equal ['a';'n';'t']
   
    [<Fact>]
    let orderByDescending () =
        seq { 'a' .. 'c' } |> Enumerable.orderByDescending (fun c -> c) |> Seq.toList |> should equal ['c';'b';'a']

    [<Fact>]
    let reverse () =
        seq { 1 .. 5 } |> Enumerable.reverse |> Seq.toList |> should equal [5;4;3;2;1]

    [<Fact>]
    let sequenceEqual () =
        (seq { 1 .. 5 }, [5;3;4;1;2] |> Seq.sortBy (fun i->i))
            ||> Enumerable.sequenceEqual |> should be True
    [<Fact>]     
    let single () =
        [1] |> Enumerable.single |> should equal 1
        //(fun () -> [] |> Enumerable.single |> ignore) |> should throw typeof<System.InvalidOperationException>
      
    [<Fact>]   
    let singleOrDefault () =
            Seq.empty<int> |> Enumerable.singleOrDefault |> should equal 0
            //(fun () -> [1;2] |> Enumerable.singleOrDefault |> ignore) |> should throw typeof<System.InvalidOperationException>
    
    
    [<Fact>]
    let thenBy () =
        let p1 = (seq { 'a' .. 'c' }, seq { 1 .. 3}) ||> Seq.zip 
        let p2 = (seq { 'x' .. 'z' }, seq { 1 .. 3}) ||> Seq.zip 
        Seq.append p1 p2 
            |> Enumerable.orderByDescending (fun (_,n)->n) 
            |> Enumerable.thenBy (fun(a,_)->a)
            |> Seq.toList
            |> should equal [('c',3);('z',3);('b',2);('y',2);('a',1);('x',1)]