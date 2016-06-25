#FSharp.Interop.Compose Extensions

inlined composable fsharp functions around BCL static methods. Supports .net 3.5 through .net Standard
##Examples

`FSharp.Interop.Compose.Linq.Enumerable`

    open FSharp.Interop.Compose.Linq

    seq { 1 .. 5 } |> Enumerable.reverse // seq [5; 4; 3; 2; ...]

    Seq.empty<int> |> Enumerable.defaultIfEmpty // seq [0]

    [("Rust", "Cohle"); ("Marty", "Hart"); ("Maggie", "Hart")]
        |> Enumerable.orderBy snd
        |> Enumerable.thenBy fst
      //seq [("Rust", "Cohle"); ("Maggie", "Hart"); ("Marty", "Hart")]

`FSharp.Interop.Compose.System.String`

    open FSharp.Interop.Compose.System

    ["One";"Two";"Three"]
       |> Seq.filter (String.startsWith "T") // seq ["Two";"Three"]

##API

See [api-docs](http://jbtule.github.io/FSharp.Interop.Compose/reference/index.html) for wrapper functions

##Use
To use precompiled dll, add with [nuget](https://www.nuget.org/packages/FSharp.Interop.Compose/)

    PM> Install-Package FSharp.Interop.Compose


##Contribute

The `generate` target of the F# make file [Make.fsx](https://github.com/jbtule/FSharp.Interop.Compose/blob/master/tools/Make.fsx) provides a mechansim to identify static base class libraries and alter their parameter order and write out the module on a per class basis.

The [tool/Generate.fsx](https://github.com/jbtule/FSharp.Interop.Compose/blob/master/tools/Generate.fsx) script provides the generalized api for generating those wrappers.

*Note: inline non-mutating instance method*

FSUnit xUnit tests can be added in `.fsx` files in the [test](https://github.com/jbtule/FSharp.Interop.Compose/tree/master/test) directory.


##Build
To build on Mono [![Build Status](https://travis-ci.org/jbtule/FSharp.Interop.Compose.png?branch=master)](https://travis-ci.org/jbtule/FSharp.Interop.Compose)

    ./build.fsx

or on Windows [![Build status](https://ci.appveyor.com/api/projects/status/6lv8sy1d21xwajwc/branch/master)](https://ci.appveyor.com/project/jbtule/FSharp.Interop.Compose)

    fsi --exec build.fsx
