#if run_with_bin_sh 
  # See why this works at http://stackoverflow.com/a/21948918/637783 
  exec fsharpi --exec $0 $*
#endif

open System
open System.IO
open System.Diagnostics

let toolsDir = Path.Combine(Environment.CurrentDirectory, "tools")

(* helper functions *)
let processStart (psi:ProcessStartInfo) =
    let ps = Process.Start(psi)
    ps.WaitForExit();
    ps.ExitCode

let setAccessPermissionUnix (path:string) =
    try 
        let monoSysCall = Type.GetType("Mono.Unix.Native.Syscall, Mono.Posix")
        if monoSysCall <> null then
            let monoEnum = Type.GetType("Mono.Unix.Native.FilePermissions, Mono.Posix")
            monoSysCall.GetMethod("chmod").Invoke(null, [|path; Enum.Parse(monoEnum,"ACCESSPERMS")|]) |> ignore
    with
        _ -> ()

(* Restore Nuget *)
let nugetExitCode =  
    ProcessStartInfo(
            Path.Combine(toolsDir, "NuGet","NuGet.exe"),
            @"install packages.config -OutputDirectory packages -ExcludeVersion",
            WorkingDirectory = toolsDir,
            UseShellExecute = false) 
    |> processStart

(* Fix permissions for Fake if Mono *)
let fakePath = Path.Combine(toolsDir, "packages","FAKE","tools", "FAKE.exe")
setAccessPermissionUnix fakePath
(* Run fake *)
let passedArgs = (fsi.CommandLineArgs |> Seq.skip 1 |> String.concat " ");

let fakeExitCode =  
    ProcessStartInfo(
        Path.Combine(toolsDir, "packages","FAKE","tools", "FAKE.exe"),
        sprintf "%s %s" (Path.Combine(toolsDir,"Make.fsx")) passedArgs,
        UseShellExecute = false)
    |> processStart

exit fakeExitCode
