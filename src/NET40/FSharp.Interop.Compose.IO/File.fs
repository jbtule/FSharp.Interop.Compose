// Generated with FSharp.Interop.Compose (1.14.0) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.IO
/// Corresponding static methods as functions for [`System.IO.File`](https://docs.microsoft.com/en-us/dotnet/api/system.io.file)
module File =

    /// Calls [`AppendAllLines(path, contents)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalllines)
    let inline appendAllLines path contents = System.IO.File.AppendAllLines(path, contents)

    /// Calls [`WriteAllLines(path, contents)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines)
    let inline writeAllLines (path:System.String) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents)

    /// Longer parameter versions of `System.IO.File` methods
    module Full =

        /// Calls [`AppendAllLines(path, contents, encoding)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalllines)
        let inline appendAllLines path encoding contents = System.IO.File.AppendAllLines(path, contents, encoding)

        /// Calls [`WriteAllLines(path, contents, encoding)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines)
        let inline writeAllLines (path:System.String) (encoding:System.Text.Encoding) (contents:System.Collections.Generic.IEnumerable<System.String>) = System.IO.File.WriteAllLines(path, contents, encoding)
