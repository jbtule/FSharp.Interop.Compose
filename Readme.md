#FSharp Composable Extensions

Searches through BCL libraries and wraps extensions methods to become composable.

##Example
```fsharp
open Composable.Linq

seq { 1 .. 5 } |> Enumerable.reverse // seq [5; 4; 3; 2; ...]

Seq.empty<int> |> Enumerable.defaultIfEmpty // seq [0]
    
[("Rust", "Cohle"); ("Marty", "Hart"); ("Maggie", "Hart")] 
    |> Enumerable.orderBy (fun (_, lastname) -> lastname)
    |> Enumerable.thenBy (fun (firstname, _) -> firstname)
  //seq [("Rust", "Cohle"); ("Maggie", "Hart"); ("Marty", "Hart")]

```
##API

See [src](https://github.com/jbtule/ComposableExtensions/tree/master/src)

##Use
To use precompiled dll, add with [nuget](https://www.nuget.org/packages/ComposableExtensions/)
```
PM> Install-Package ComposableExtensions
```
##Build
To build on Mono [![Build Status](https://travis-ci.org/jbtule/ComposableExtensions.png?branch=master)](https://travis-ci.org/jbtule/ComposableExtensions)
```
./build.fsx 
```
or on Windows
```
fsi -exec build.fsx
```
