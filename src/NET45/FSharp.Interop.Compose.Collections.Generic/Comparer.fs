// Generated with FSharp.Interop.Compose (1.14.0) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.Collections.Generic
/// Corresponding static methods as functions for [`System.Collections.Generic.Comparer`](http://msdn.microsoft.com/en-us/library/system.collections.generic.comparer)
module Comparer =

    /// Calls [`Create(System.Comparison<'T>(comparison))`](http://msdn.microsoft.com/en-us/library/system.collections.generic.comparer.create)
    let inline create<'T> (comparison:'T->'T->System.Int32) = System.Collections.Generic.Comparer<'T>.Create(System.Comparison<'T>(comparison))