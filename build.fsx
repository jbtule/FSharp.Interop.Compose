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

let passedArg = fsi.CommandLineArgs.[1..] |> Array.tryHead

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

type actions = { gen:bool; docs:bool; build:bool; clean:bool; test:bool }

let choice =
    match passedArg with 
        | Some(x) when x.Equals("Generate", StringComparison.InvariantCultureIgnoreCase) ->
            printfn "Generate target";
            { gen= true; docs=false; build =false; clean = true; test= false}
        | Some(x) when x.Equals("Clean", StringComparison.InvariantCultureIgnoreCase) ->
            printfn "Clean target";
            { gen= false; docs=false; build =false; clean = true; test= false}
        | _ -> 
            printfn "Default target";
            { gen= true; docs=true; build = true; clean = true; test= true}
 
let msbuild = CompilerHelper.findMSBuild();

if choice.clean then
    SimpleMake.clean srcDir
#if !mono_posix
    SimpleMake.clean docsBuildDir
#endif
    SimpleMake.clean "proj/bin/"
    SimpleMake.clean "proj/obj/"
    SimpleMake.clean "test/bin/"
    SimpleMake.clean "test/obj/"

if choice.gen then
    SimpleMake.generate ()

if choice.build then
    let msbuild = CompilerHelper.findMSBuild();
    execAt "proj/" msbuild [
                              "/t:restore" 
                              sprintf "/p:VersionSuffix=%s" versionSuffix
                           ]
    execAt "proj/" msbuild [
                             sprintf "/p:VersionSuffix=%s" versionSuffix
                           ]

if choice.test then
    execAt "test/" msbuild ["/t:restore"]
    execAt "test/" msbuild []
    let xunitTools = Path.Combine("tools","packages", "xunit.runner.console","tools")
    let dotnet = findDotNet ()
    execAt "test/" dotnet   [
                                Path.Combine("..", xunitTools, "netcoreapp2.0","xunit.console.dll")
                                Path.Combine("bin", configuration, "netcoreapp2.0", "Test.dll" )
                            ]
    let xunitRunner =  Path.Combine(xunitTools, "net452","xunit.console.exe") |> Path.GetFullPath
    execAt "test/" xunitRunner [  Path.Combine("bin", configuration, "net47", "Test.exe" ) ]

#if !mono_posix
if choice.docs then
    DocHelper.generateDocs ()
#endif