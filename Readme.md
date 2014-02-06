#FSharp Composable Extensions

Searches through BCL libraries and wraps extensions methods to become composable.

##Example
```F#
open Composable.Linq

seq { 1 .. 5 } |> Enumerable.reverse // seq [5; 4; 3; 2; ...]

Seq.empty<int> |> Enumerable.defaultIfEmpty // seq [0]

```
##API

See [gensrc](https://github.com/jbtule/ComposableExtensions/tree/master/gensrc)

##Use
To use precompiled dll, add with [nuget](https://www.nuget.org/packages/ComposableExtensions/)
```
PM> Install-Package ComposableExtensions
```
##Build
To build on Mono
```
./build.sh 
```
or on Windows
```
./build.cmd
```
