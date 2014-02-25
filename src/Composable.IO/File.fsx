// Generated with ComposableExtensions (0.8.1) http://jbtule.github.io/ComposableExtensions

/// Corresponding `System.IO.File` static methods as functions
module Composable.IO.File

/// Calls `WriteAllLines(path, contents)`
let inline writeAllLines (path:System.String) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents)
