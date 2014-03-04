// Generated with ComposableExtensions (0.10.2) http://jbtule.github.io/ComposableExtensions

namespace Composable.IO
/// Corresponding `System.IO.File` static methods as functions
module File =

    /// Calls `AppendAllLines(path, contents)`
    let inline appendAllLines path contents = System.IO.File.AppendAllLines(path, contents)

    /// Calls `WriteAllLines(path, contents)`
    let inline writeAllLines (path:System.String) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents)

    /// Longer parameter versions of `System.IO.File` methods
    module Full =

        /// Calls `AppendAllLines(path, contents, encoding)`
        let inline appendAllLines path encoding contents = System.IO.File.AppendAllLines(path, contents, encoding)

        /// Calls `WriteAllLines(path, contents, encoding)`
        let inline writeAllLines (path:System.String) (encoding:System.Text.Encoding) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents, encoding)
