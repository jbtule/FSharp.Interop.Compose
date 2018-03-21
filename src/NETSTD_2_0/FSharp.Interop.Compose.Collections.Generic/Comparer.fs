// Generated with FSharp.Interop.Compose (2.0.1) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.Collections.Generic
/// Corresponding static methods as functions for [`System.Collections.Generic.Comparer`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.comparer)
module Comparer =

    /// Calls [`Create(System.Comparison<'T>(comparison))`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.comparer.create)
    let inline create<'T> (comparison:'T->'T->System.Int32) = System.Collections.Generic.Comparer<'T>.Create(System.Comparison<'T>(comparison))
