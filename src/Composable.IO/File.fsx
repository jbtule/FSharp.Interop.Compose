// Generated with ComposableExtensions (0.10.4) http://jbtule.github.io/ComposableExtensions

namespace Composable.IO
/// Corresponding static methods as functions for [`System.IO.File`](http://msdn.microsoft.com/en-us/library/system.io.file)
module File =

    /// Calls [`AppendAllLines(path, contents)`](http://msdn.microsoft.com/en-us/library/system.io.file.appendalllines)
    let inline appendAllLines path contents = System.IO.File.AppendAllLines(path, contents)

    /// Calls [`WriteAllLines(path, contents)`](http://msdn.microsoft.com/en-us/library/system.io.file.writealllines)
    let inline writeAllLines (path:System.String) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents)

    /// Longer parameter versions of `System.IO.File` methods
    module Full =

        /// Calls [`AppendAllLines(path, contents, encoding)`](http://msdn.microsoft.com/en-us/library/system.io.file.appendalllines)
        let inline appendAllLines path encoding contents = System.IO.File.AppendAllLines(path, contents, encoding)

        /// Calls [`WriteAllLines(path, contents, encoding)`](http://msdn.microsoft.com/en-us/library/system.io.file.writealllines)
        let inline writeAllLines (path:System.String) (encoding:System.Text.Encoding) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents, encoding)
