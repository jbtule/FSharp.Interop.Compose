@echo off

cls

if not exist buildpackages\FAKE\tools\Fake.exe (
    "tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "buildpackages" "-ExcludeVersion" 
)

if not exist buildpackages\FSharp.Compiler.Service\lib\net40\FSharp.Compiler.Service.dll (
    "tools\nuget\nuget.exe" "install" "FSharp.Compiler.Service" "-OutputDirectory" "buildpackages" "-ExcludeVersion"
)

if not exist buildpackages\Mono.Cecil\lib\net40\Mono.Cecil.dll (
    "tools\nuget\nuget.exe" "install" "Mono.Cecil" "-OutputDirectory" "buildpackages" "-ExcludeVersion"
)

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%1")
  
"buildpackages\FAKE\tools\Fake.exe" "build.fsx" "target=%TARGET%"
exit /b %errorlevel%