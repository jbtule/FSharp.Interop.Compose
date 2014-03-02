#FSharp Composable Extensions

inlined composable fsharp functions around BCL static methods.

##Examples

`Composable.Linq.Enumerable`

    open Composable.Linq

    seq { 1 .. 5 } |> Enumerable.reverse // seq [5; 4; 3; 2; ...]

    Seq.empty<int> |> Enumerable.defaultIfEmpty // seq [0]

    [("Rust", "Cohle"); ("Marty", "Hart"); ("Maggie", "Hart")]
        |> Enumerable.orderBy (fun (_, lastname) -> lastname)
        |> Enumerable.thenBy (fun (firstname, _) -> firstname)
      //seq [("Rust", "Cohle"); ("Maggie", "Hart"); ("Marty", "Hart")]

`Composable.System.String`

    open Composable.System

    ["1";"";"2";"  "; "3"; null; "4"]
       |> Seq.filter (not << String.isNullOrWhiteSpace) //seq["1";"2";"3";"4"]

##API

See [api-docs](http://jbtule.github.io/ComposableExtensions/reference/index.html) for wrapper functions

##Use
To use precompiled dll, add with [nuget](https://www.nuget.org/packages/ComposableExtensions/)

    PM> Install-Package ComposableExtensions


##Contribute

The `generate` target of the F# make file [Make.fsx](https://github.com/jbtule/ComposableExtensions/blob/master/tools/Make.fsx) provides a mechansim to identify static base class libraries and alter their parameter order and write out the module on a per class basis.

The [tool/Generate.fsx](https://github.com/jbtule/ComposableExtensions/blob/master/tools/Generate.fsx) script provides the generalized api for generating those wrappers.

*Note: inline non-mutating instance method*

FSUnit xUnit tests can be added in `.fsx` files in the [test](https://github.com/jbtule/ComposableExtensions/tree/master/test) directory.


##Build
To build on Mono [![Build Status](https://travis-ci.org/jbtule/ComposableExtensions.png?branch=master)](https://travis-ci.org/jbtule/ComposableExtensions)

    ./build.fsx

or on Windows [![Build status](https://ci-beta.appveyor.com/api/projects/status/gy56e6su3e02e20i/branch/master)](https://ci-beta.appveyor.com/project/jbtule/composableextensions)

    fsi --exec build.fsx
