#!/bin/bash
if [ ! -f buildpackages/FAKE/tools/Fake.exe ]; then
  mono --runtime=v4.0 tools/NuGet/NuGet.exe install FAKE -OutputDirectory buildpackages -ExcludeVersion
fi
if [ ! -f buildpackages/FSharp.Compiler.Service/lib/net40/FSharp.Compiler.Service.dll ]; then
  mono --runtime=v4.0 tools/NuGet/NuGet.exe install FSharp.Compiler.Service -OutputDirectory buildpackages -ExcludeVersion
fi
if [ ! -f buildpackages/Mono.Cecil/lib/net40/Mono.Cecil.dll ]; then
  mono --runtime=v4.0 tools/NuGet/NuGet.exe install Mono.Cecil -OutputDirectory buildpackages -ExcludeVersion
fi
mono --runtime=v4.0 buildpackages/FAKE/tools/FAKE.exe build.fsx $@