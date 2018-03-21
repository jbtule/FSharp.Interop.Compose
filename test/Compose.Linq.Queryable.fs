namespace Test.FSharp.Interop.Compose.Linq

#if NET35
#else
open Xunit
open FsUnit.Xunit
open FSharp.Interop.Compose.Linq

module ``Queryable Basic Tests`` =



    [<Fact>]
    let where () =
        [1;4;5;6;7;8;1;4;5;6;7;8]
            |> Queryable.asQueryable
            |> Queryable.where <@ (fun i -> i < 5) @>
            |> Seq.toList
            |> should equal [1;4;1;4]



#endif
