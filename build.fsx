#!/bin/sh
#if bin_sh
  # Doing this because arguments can't be used with /usr/bin/env on linux, just mac
  exec fsharpi --define:mono_posix --exec $0 $*
#endif
(*
 * CrossPlatform FSharp Makefile bootstraper - jay+code@tuley.name
 *
 * How to use:
 *   On Windows `fsi --exec build.fsx <buildtarget>
 *
 *  On Mac Or Linux `./build.fsx <buildtarget>`
 *    *Note:* But if you have trouble then use `sh build.fsx <buildtarget>`
 *
 *)

open System
open System.IO
open System.Diagnostics

(* helper functions *)

#if mono_posix
#r "Mono.Posix.dll"
open Mono.Unix.Native
let applyExecutionPermissionUnix path =
    let _,stat = Syscall.lstat(path)
    Syscall.chmod(path, FilePermissions.S_IXUSR ||| stat.st_mode) |> ignore
#else
let applyExecutionPermissionUnix path = ()
#endif

let doesNotExist path =
    path |> Path.GetFullPath |> File.Exists |> not

let execAt (workingDir:string) (exePath:string) (args:string seq) =
    let processStart (psi:ProcessStartInfo) =
        let ps = Process.Start(psi)
        ps.WaitForExit ()
        ps.ExitCode
    let fullExePath = exePath |> Path.GetFullPath
    applyExecutionPermissionUnix fullExePath
    let exitCode = ProcessStartInfo(
                        fullExePath,
                        args |> String.concat " ",
                        WorkingDirectory = (workingDir |> Path.GetFullPath),
                        UseShellExecute = false) 
                   |> processStart
    if exitCode <> 0 then
        exit exitCode
    ()


let downloadNugetTo path =
    let fullPath = path |> Path.GetFullPath;
    if doesNotExist fullPath then 
        printf "Downloading NuGet..."
        use webClient = new System.Net.WebClient()
        fullPath |> Path.GetDirectoryName |> Directory.CreateDirectory |> ignore
        webClient.DownloadFile("https://dist.nuget.org/win-x86-commandline/latest/nuget.exe", path |> Path.GetFullPath)
        printfn "Done."

let passedArgs = fsi.CommandLineArgs.[1..] |> Array.toList

(* execution script customize below *)

downloadNugetTo "tools/NuGet/NuGet.exe"

execAt
    "tools/"
    "tools/NuGet/NuGet.exe"
    ["install"; "-OutputDirectory packages"; "-ExcludeVersion"]

execAt
    "tools/std20"
    "tools/NuGet/NuGet.exe"
    ["install"; "-OutputDirectory packages"; "-ExcludeVersion"]

#load "tools/SimpleMake.fsx"
