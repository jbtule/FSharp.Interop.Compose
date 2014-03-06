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

    let allPaths = 
        [ 
            NET45, [
              Path.Combine(msSDK,".NETFramework", "v4.5")
              Path.Combine(sysDotNetLibPath,"4.5")
              Path.Combine(sysDotNetLibPath,"v4.0.30319")
            ]
            NET40, [
              Path.Combine(msSDK,".NETFramework","v4.0")
              Path.Combine(sysDotNetLibPath,"4.0")
              Path.Combine(sysDotNetLibPath,"v4.0.30319")
            ]
            NET35, [
              Path.Combine(msSDK,".NETFramework","v3.5", "Profile", "Client")
              Path.Combine(sysDotNetLibPath,"3.5")
              Path.Combine(sysDotNetLibPath,"v3.5")
              Path.Combine(sysDotNetLibPath,"v2.0.50727")
            ]
            PORTABLE_47, [
                Path.Combine(msSDK, ".NETPortable", "v4.0", "Profile", "Profile47")
                Path.Combine(sysDotNetLibPath,"xbuild-framework", ".NETPortable", "v4.0", "Profile", "Profile47")
            ]
        ] |> Map.ofSeq

    let systemDlls =
        [
            "mscorlib.dll"
            "System.dll"
            "System.Core.dll"
        ]

    let searchPaths = allPaths.[target]
                        |> Seq.map (fun p-> Path.GetFullPath p)
                        |> Seq.filter (fun p -> Directory.Exists p)

    let fsharpCore =
        match target with
            | PORTABLE_47 -> Path.Combine(fsharpSDK30, "Runtime", ".NETPortable" , "FSharp.Core.dll")
            | NET35 -> "./tools/packages/FSharp.Core.3/lib/net20/FSharp.Core.dll"
            | NET40 | NET45 -> "./tools/packages/FSharp.Core.3/lib/net40/FSharp.Core.dll"
        |> Path.GetFullPath

    let dllPath dll =
        searchPaths
            |> Seq.map (fun p -> Path.Combine(p, dll))
            |> Seq.tryFind (fun p -> File.Exists(p))

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