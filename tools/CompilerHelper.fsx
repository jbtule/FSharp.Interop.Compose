[<AutoOpen>]
module CompilerHelper

#I "packages/FSharp.Compiler.Service/lib/net40/"
#r "FSharp.Compiler.Service.dll"
#I "packages/FAKE/tools"
#r "FakeLib.dll"

open Microsoft.FSharp.Compiler.SimpleSourceCodeServices
open Fake.TraceHelper
open System.IO
open System.Reflection

type TargetFramework =
    | NET45
    | NET40
    | NET35
    | PORTABLE_47
    | PORTABLE_7


let systemDllsTargeting (target:TargetFramework) =
    let programFiles = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86)
    let msSDK = Path.Combine (programFiles, "Reference Assemblies","Microsoft","Framework");
    let fsharpSDK = Path.Combine (programFiles, "Reference Assemblies","Microsoft","FSharp");
    let fsharpSDK30 = Path.Combine (fsharpSDK,"3.0");



    printfn "%s" msSDK
    let sysDotNetLibPath =
        Assembly.GetAssembly(typeof<System.Object>).Location
             |> Path.GetDirectoryName
             |> (fun x -> Path.Combine(x, ".."))
             |> Path.GetFullPath

    let allStdPaths =
        match target with
            | NET45 ->
                [
                  Path.Combine(msSDK,".NETFramework", "v4.5") //Windows
                  Path.Combine(sysDotNetLibPath,"4.5") //Mono
                  Path.Combine(sysDotNetLibPath,"v4.0.30319") //Windows Fallback
                ]
            | NET40 ->
                [
                  Path.Combine(msSDK,".NETFramework","v4.0") //Windows
                  Path.Combine(sysDotNetLibPath,"4.0") //Mono
                  Path.Combine(sysDotNetLibPath,"v4.0.30319") //Windows Fallback
                ]
            | NET35 ->
                [
                  Path.Combine(msSDK,".NETFramework","v3.5", "Profile", "Client") //Windows
                  Path.Combine(sysDotNetLibPath,"3.5") //Mono
                  Path.Combine(sysDotNetLibPath,"2.0") //Mono
                  Path.Combine(sysDotNetLibPath,"v3.5") //Windows Fallback
                  Path.Combine(sysDotNetLibPath,"v2.0.50727") //Windows Fallback
                ]
            | PORTABLE_47 ->
                [
                    Path.Combine(msSDK, ".NETPortable", "v4.0", "Profile", "Profile47") //Windows
                    Path.Combine(sysDotNetLibPath,"xbuild-framework", ".NETPortable", "v4.0", "Profile", "Profile47") //Mono
                ]
            | PORTABLE_7 ->
                [
                    Path.Combine(msSDK, ".NETPortable", "v4.5", "Profile", "Profile7") //Windows
                    Path.Combine(sysDotNetLibPath,"xbuild-framework", ".NETPortable", "v4.5", "Profile", "Profile7") //Mono
                ]
        |> List.map Path.GetFullPath


    let fsharpPaths =
        match target with
            | PORTABLE_47 ->
                [
                    Path.Combine(fsharpSDK, ".NETPortable", "2.351") //Windows F# 3.1
                    Path.Combine(fsharpSDK, ".NETPortable", "2.350") //Windows F# 3.0
                    Path.Combine(fsharpSDK30, "Runtime", ".NETPortable") //Windows F#3.0
                ]
            | PORTABLE_7 ->
                [
                    Path.Combine(fsharpSDK, ".NETCore", "3.310") //Windows F# 3.1
                ]
            | NET35 ->
                [
                    Path.Combine(fsharpSDK, ".NETFramework","v2.0", "2.300") //Windows F# 3.0 new loc
                    Path.Combine(fsharpSDK30, "Runtime", "v2.0") //Windows F# 3.0
                    Path.Combine(sysDotNetLibPath, "2.1") //Mono
                    "./tools/packages/FSharp.Core.3/lib/net20/" //Fallback
                ]
            | NET40 ->
                [
                    Path.Combine(fsharpSDK, ".NETFramework","v4.0", "4.310") //Windows F# 3.1
                    Path.Combine(fsharpSDK, ".NETFramework","v4.0", "4.300") //Windows F# 3.0 new loc
                    Path.Combine(fsharpSDK30, "Runtime", "v4.0") //Windows F# 3.0
                    Path.Combine(sysDotNetLibPath, "4.0") //Mono
                    "./tools/packages/FSharp.Core.3/lib/net40/"
                ]
            | NET45 ->
                [
                    Path.Combine(fsharpSDK, ".NETFramework","v4.0", "4.310") //Windows F# 3.1
                    Path.Combine(fsharpSDK, ".NETFramework","v4.0", "4.300") //Windows F# 3.0 new loc
                    Path.Combine(fsharpSDK30, "Runtime", "v4.0") //Windows F# 3.0
                    Path.Combine(sysDotNetLibPath, "4.5") //Mono
                    "./tools/packages/FSharp.Core.3/lib/net40/" //Fallback
                ]
        |> List.map Path.GetFullPath

    let systemDlls =
        [
            "mscorlib.dll"
            "System.dll"
            "System.Core.dll"
        ]

    let searchPaths (paths:string list) =
        paths
            |> Seq.map (fun p-> Path.GetFullPath p)
            |> Seq.filter (fun p -> Directory.Exists p)



    let fsharpCore =
        searchPaths fsharpPaths
            |> Seq.map (fun p -> Path.Combine(p, "FSharp.Core.dll"))
            |> Seq.find File.Exists

    let dllPath dll =
        searchPaths allStdPaths
            |> Seq.map (fun p -> Path.Combine(p, dll))
            |> Seq.tryFind File.Exists

    systemDlls
        |> List.choose dllPath
        |> List.append [fsharpCore]

let fscTargetingHelper (target:TargetFramework option) (args:string list) =

    let sysDlls =
        match target with
        | Some(t) -> systemDllsTargeting t
                        |> List.map (fun p-> sprintf "--reference:%s" p)
                        |> List.append ["--noframework"]
        | None -> []

    let compilerOpts = ["fsc.exe"] @ sysDlls @ args
    log (compilerOpts|> String.concat " ")
    let scs = SimpleSourceCodeServices()
    let errors,errorCode = scs.Compile(compilerOpts |> List.toArray)
    for e in errors do
        let errMsg = e.ToString()
        match e.Severity with
            | Microsoft.FSharp.Compiler.Warning -> traceImportant errMsg
            | Microsoft.FSharp.Compiler.Error -> traceError errMsg
    if errorCode = 0 then
        trace "Compile Success"
    else
        raise (System.Exception "Compile Failed")
    ()

let fsc = fscTargetingHelper None
let fscTargeting target = fscTargetingHelper (Some(target))
