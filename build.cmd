@echo off

cls

if not exist tools\packages\FAKE\tools\Fake.exe (
    "tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools\packages" "-ExcludeVersion" 
)

if not exist tools\packages\FSharp.Compiler.Service\lib\net40\FSharp.Compiler.Service.dll (
    "tools\nuget\nuget.exe" "install" "FSharp.Compiler.Service" "-OutputDirectory" "tools\packages" "-ExcludeVersion"
)

if not exist tools\packages\Mono.Cecil\lib\net40\Mono.Cecil.dll (
    "tools\nuget\nuget.exe" "install" "Mono.Cecil" "-OutputDirectory" "tools\packages" "-ExcludeVersion"
)

if not exist tools\packages\FsUnit.xUnit\lib\net40\FsUnit.xUnit.dll (
    "tools\nuget\nuget.exe" "install" "FsUnit.xUnit" "-OutputDirectory" "tools\packages" "-ExcludeVersion"
)

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%1")
  
"tools\packages\FAKE\tools\Fake.exe" "build.fsx" "target=%TARGET%"
exit /b %errorlevel%