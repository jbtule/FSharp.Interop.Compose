// Copyright 2014 Jay Tuley <jay+code@tuley.name>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


[<AutoOpen>]
module CompilerHelper
open System

#I "packages/FSharp.Compiler.Service/lib/net45/"
#r "FSharp.Compiler.Service.dll"

open System.IO
open System.Reflection

type TargetFramework =
    | NET45
    | NET40
    | NET35
    | PORTABLE_47
    | PORTABLE_259
    | NETSTD_2_0

let msbuildProp arg v = if String.IsNullOrWhiteSpace(v) then
                             String.Empty
                          else
                             sprintf "/p:%s=%s" arg v

let sysDotNetLibPath =
        Assembly.GetAssembly(typeof<System.Object>).Location
             |> Path.GetDirectoryName
             |> (fun x -> Path.Combine(x, ".."))
             |> Path.GetFullPath

let msbuildPaths = [
                    Path.Combine("Microsoft Visual Studio", "2017","Enterprise", "MSBuild", "15.0", "Bin" )
                    Path.Combine("Microsoft Visual Studio", "2017","Professional", "MSBuild", "15.0", "Bin" )
                    Path.Combine("Microsoft Visual Studio", "2017","Community", "MSBuild", "15.0", "Bin" )
                    Path.Combine("MSBuild","15.0", "Bin" )
                    Path.Combine("Microsoft Visual Studio", "2017","BuildTools", "MSBuild", "15.0", "Bin" )
                   ] 
                     |> List.map (fun x-> Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), x))
                     |> List.append [
                                      Path.Combine("/Library","Frameworks","Mono.framework","Versions","Current","Commands")
                                      Path.Combine(sysDotNetLibPath,"msbuild", "15.0", "bin")
                                      Path.Combine("/usr","bin")
                                    ]

let findMSBuild () =
        msbuildPaths
            |> Seq.map Path.GetFullPath
            |> Seq.filter Directory.Exists
            |> Seq.collect (fun p -> [Path.Combine(p, "msbuild"); Path.Combine(p, "msbuild.exe")])
            |> Seq.tryFind File.Exists
            |> Option.defaultValue "msbuild"

let dotnetExePath = [
                        Path.Combine(@"C:\Program Files", "dotnet")
                        Path.Combine("/usr","local","share","dotnet")
                        Path.Combine("/usr","share","dotnet")
                    ]
let findDotNet () =
        dotnetExePath
            |> Seq.map Path.GetFullPath
            |> Seq.filter Directory.Exists
            |> Seq.collect (fun p -> [Path.Combine(p, "dotnet"); Path.Combine(p, "dotnet.exe")])
            |> Seq.tryFind File.Exists
            |> Option.defaultValue "dotnet"



let defaultSystemDlls (target:TargetFramework) =
    match target with
        | NET45 | NET40 ->
            [
                "mscorlib.dll"
                "System.dll"
                "System.Core.dll"
                "System.Numerics.dll"

                "System.Collections.dll"
                "System.Diagnostics.Debug.dll"
                "System.Globalization.dll"
                "System.IO.dll"
                "System.Linq.dll"
                "System.Linq.Expressions.dll"
                "System.Linq.Queryable.dll"
                "System.Net.dll"
                "System.Net.Requests.dll"
                "System.Reflection.dll"
                "System.Reflection.Extensions.dll"
                "System.Resources.ResourceManager.dll"
                "System.Runtime.dll"
                "System.Runtime.Extensions.dll"
                "System.Runtime.Numerics.dll"
                "System.Text.RegularExpressions.dll"
                "System.Text.Encoding.dll"
                "System.Threading.dll"
                "System.Threading.Tasks.dll"
                "System.Threading.Tasks.Parallel.dll"
            ]
        | PORTABLE_47 ->
            [
                "mscorlib.dll"
                "System.dll"
                "System.Core.dll"
                "System.Numerics.dll"
                "System.Net.dll"
            ]
        | NET35 ->
            [
                "mscorlib.dll"
                "System.dll"
                "System.Core.dll"
            ]
        | PORTABLE_259 ->
            [   
                "mscorlib.dll"
                "System.dll"
                "System.Core.dll"
                "System.Collections.dll"
                "System.Diagnostics.Debug.dll"
                "System.Globalization.dll"
                "System.IO.dll"
                "System.Linq.dll"
                "System.Linq.Expressions.dll"
                "System.Linq.Queryable.dll"
                "System.Net.dll"
                "System.Net.Requests.dll"
                "System.Reflection.dll"
                "System.Reflection.Extensions.dll"
                "System.Resources.ResourceManager.dll"
                "System.Runtime.dll"
                "System.Runtime.Extensions.dll"
                "System.Runtime.Numerics.dll"
                "System.Text.RegularExpressions.dll"
                "System.Text.Encoding.dll"
                "System.Threading.dll"
                "System.Threading.Tasks.dll"
                "System.Threading.Tasks.Parallel.dll"
            ]
        | NETSTD_2_0 ->
            [   
                "netstandard.dll"
            ]

let systemTargetInfo (target:TargetFramework) =
    (defaultSystemDlls target, target)

let systemDllsResolver (systemDlls:string list,target:TargetFramework) =
    let programFiles = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86)
    let msSDK = Path.Combine (programFiles, "Reference Assemblies","Microsoft","Framework");
    let fsharpSDK = Path.Combine (programFiles, "Reference Assemblies","Microsoft","FSharp");
    let fsharpSDK30 = Path.Combine (fsharpSDK,"3.0");



    let monoFSharpSDK = Path.Combine (sysDotNetLibPath, "Reference Assemblies","Microsoft","FSharp");
    let allStdPaths =
        match target with
            | NETSTD_2_0 ->
                [
                    "./tools/std20/packages/NETStandard.Library/build/netstandard2.0/ref/"
                ]
            | NET45 ->
                [
                  Path.Combine(msSDK,".NETFramework", "v4.5.1", "Facades") 
                  Path.Combine(msSDK,".NETFramework", "v4.5.1") //Windows
                  Path.Combine(msSDK,".NETFramework", "v4.5") //Windows
                  Path.Combine(sysDotNetLibPath,"4.5-api", "Facades") 
                  Path.Combine(sysDotNetLibPath,"4.5-api") //Mono
                  Path.Combine(sysDotNetLibPath,"4.5", "Facades") 
                  Path.Combine(sysDotNetLibPath,"4.5") //Mono
                ]
            | NET40 ->
                [
                  Path.Combine(msSDK,".NETFramework","v4.0") //Windows
                  Path.Combine(sysDotNetLibPath,"4.0-api") //Mono
                  Path.Combine(sysDotNetLibPath,"4.0") //Mono
                ]
            | NET35 ->
                [
                  Path.Combine(msSDK,".NETFramework","v3.5", "Profile", "Client") //Windows
                  Path.Combine(sysDotNetLibPath,"3.5-api") //Mono
                  Path.Combine(sysDotNetLibPath,"2.0-api") //Mono
                  Path.Combine(sysDotNetLibPath,"3.5") //Mono
                  Path.Combine(sysDotNetLibPath,"2.0") //Mono
                ]
            | PORTABLE_259 ->
                [
                    Path.Combine(msSDK, ".NETPortable", "v4.5", "Profile", "Profile259") //Windows
                    Path.Combine(sysDotNetLibPath,"xbuild-frameworks", ".NETPortable", "v4.5", "Profile", "Profile259") //Mono
                ]
            | PORTABLE_47 ->
                [
                    Path.Combine(msSDK, ".NETPortable", "v4.0", "Profile", "Profile47") //Windows
                    Path.Combine(sysDotNetLibPath,"xbuild-frameworks", ".NETPortable", "v4.0", "Profile", "Profile47") //Mono
                ]
        |> List.map Path.GetFullPath


    let fsharpPaths =
        match target with
            | NETSTD_2_0 ->
                [
                   "./tools/std20/packages/FSharp.Core/lib/netstandard1.6/"
                ]
            | PORTABLE_47 ->
                [   Path.Combine(fsharpSDK, ".NETPortable", "2.3.5.1") //Windows F# 3.1
                    Path.Combine(monoFSharpSDK, ".NETPortable", "2.3.5.1") //Mono F# 3.1
                    Path.Combine(fsharpSDK, ".NETPortable", "2.3.5.0") //Windows F# 3.0
                    Path.Combine(fsharpSDK30, "Runtime", ".NETPortable") //Windows F#3.0
                    Path.Combine(monoFSharpSDK, ".NETPortable", "2.3.5.0") //Mono F# 3.0
                    "./tools/packages/FSharp.Core.Microsoft.Signed/lib/portable-net45+sl5+netcore45+MonoAndroid1+MonoTouch1/"  //Fallback
                    "./tools/packages/FSharp.Core.4.3.0.0.Microsoft.Signed/lib/portable-net45+sl5+netcore45+MonoAndroid1+MonoTouch1/"  //Fallback
                ]
            | PORTABLE_259 ->
                [
                    Path.Combine(fsharpSDK, ".NETPortable", "3.47.4.0") // F# 4.0
                    "./tools/packages/FSharp.Core.Microsoft.Signed/lib/portable-net45+netcore45+wpa81+wp8+MonoAndroid1+MonoTouch1/"  //Fallback
                ]
            | NET35 ->
                [
                    Path.Combine(fsharpSDK, ".NETFramework","v2.0", "2.3.0.0") //Windows F# 3.0 new loc
                    Path.Combine(fsharpSDK30, "Runtime", "v2.0") //Windows F# 3.0
                    //Path.Combine(sysDotNetLibPath, "2.0") //Mono what version though?
                    "./tools/packages/FSharp.Core.4.3.0.0.Microsoft.Signed/lib/net35/"  //Fallback
                ]
            | NET40 ->
                [
                    Path.Combine(fsharpSDK, ".NETFramework","v4.0", "4.3.0.0") //Windows F# 3.0 new loc
                    Path.Combine(fsharpSDK30, "Runtime", "v4.0") //Windows F# 3.0
                    //Path.Combine(sysDotNetLibPath, "4.0") //Mono what version though?
                    "./tools/packages/FSharp.Core.4.3.0.0.Microsoft.Signed/lib/net40/"  //Fallback
                ]
            | NET45 ->
                [
                    Path.Combine(fsharpSDK, ".NETFramework","v4.0", "4.3.1.0") //Windows F# 3.1
                    Path.Combine(fsharpSDK, ".NETFramework","v4.0", "4.3.0.0") //Windows F# 3.0 new loc
                    Path.Combine(fsharpSDK30, "Runtime", "v4.0") //Windows F# 3.0
                    //Path.Combine(sysDotNetLibPath, "4.5") //Mono what version though?
                    "./tools/packages/FSharp.Core.Microsoft.Signed/lib/net45/" //Fallback
                    "./tools/packages/FSharp.Core.4.3.0.0.Microsoft.Signed/lib/net45/" //Fallback
                ]
        |> List.map Path.GetFullPath

    let searchPaths (paths:string list) =
        paths
            |> Seq.map Path.GetFullPath
            |> Seq.filter Directory.Exists

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

