// Generated with FSharp.Interop.Compose (2.0.1) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.IO
/// Corresponding static methods as functions for [`System.IO.Path`](https://docs.microsoft.com/en-us/dotnet/api/system.io.path)
module Path =

    /// Calls [`ChangeExtension(path, extension)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.changeextension)
    let inline changeExtension extension path = System.IO.Path.ChangeExtension(path, extension)

    /// Calls [`Combine(path1, path2)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.combine)
    let inline combine path2 path1 = System.IO.Path.Combine(path1, path2)

    /// Calls [`GetDirectoryName(path)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getdirectoryname)
    let inline getDirectoryName path = System.IO.Path.GetDirectoryName(path)

    /// Calls [`GetExtension(path)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getextension)
    let inline getExtension path = System.IO.Path.GetExtension(path)

    /// Calls [`GetFileName(path)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getfilename)
    let inline getFileName path = System.IO.Path.GetFileName(path)

    /// Calls [`HasExtension(path)`](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.hasextension)
    let inline hasExtension path = System.IO.Path.HasExtension(path)
