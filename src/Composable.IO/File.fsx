// Generated with ComposableExtensions (0.9.0) http://jbtule.github.io/ComposableExtensions

namespace Composable.IO
/// Corresponding `System.IO.File` static methods as functions
module File =

    /// Calls `WriteAllLines(path, contents)`
    let inline writeAllLines (path:System.String) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents)
