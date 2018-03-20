// Generated with FSharp.Interop.Compose (1.14.0) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.IO
/// Corresponding static methods as functions for [`System.IO.Path`](http://msdn.microsoft.com/en-us/library/system.io.path)
module Path =

    /// Calls [`ChangeExtension(path, extension)`](http://msdn.microsoft.com/en-us/library/system.io.path.changeextension)
    let inline changeExtension extension path = System.IO.Path.ChangeExtension(path, extension)

    /// Calls [`GetDirectoryName(path)`](http://msdn.microsoft.com/en-us/library/system.io.path.getdirectoryname)
    let inline getDirectoryName path = System.IO.Path.GetDirectoryName(path)

    /// Calls [`GetExtension(path)`](http://msdn.microsoft.com/en-us/library/system.io.path.getextension)
    let inline getExtension path = System.IO.Path.GetExtension(path)

    /// Calls [`GetFileName(path)`](http://msdn.microsoft.com/en-us/library/system.io.path.getfilename)
    let inline getFileName path = System.IO.Path.GetFileName(path)

    /// Calls [`HasExtension(path)`](http://msdn.microsoft.com/en-us/library/system.io.path.hasextension)
    let inline hasExtension path = System.IO.Path.HasExtension(path)
