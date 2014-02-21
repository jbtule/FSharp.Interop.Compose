// Generated with ComposableExtensions (0.6.2) https://github.com/jbtule/ComposableExtensions

module Composable.IO.File
let inline writeAllLines (path:System.String) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents)
