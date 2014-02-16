#!/bin/bash
if [ ! -f tools/packages/FAKE/tools/Fake.exe ]; then
  mono --runtime=v4.0 tools/NuGet/NuGet.exe install FAKE -OutputDirectory tools/packages -ExcludeVersion
fi
if [ ! -f tools/packages/FSharp.Compiler.Service/lib/net40/FSharp.Compiler.Service.dll ]; then
  mono --runtime=v4.0 tools/NuGet/NuGet.exe install FSharp.Compiler.Service -OutputDirectory tools/packages -ExcludeVersion
fi
if [ ! -f tools/packages/Mono.Cecil/lib/net40/Mono.Cecil.dll ]; then
  mono --runtime=v4.0 tools/NuGet/NuGet.exe install Mono.Cecil -OutputDirectory tools/packages -ExcludeVersion
fi
mono --runtime=v4.0 tools/packages/FAKE/tools/FAKE.exe build.fsx $@