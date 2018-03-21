#load "CompilerHelper.fsx"
open System.Linq
#load "Vars.fsx"
#load "Generate.fsx"
#load "Docs.fsx"

open System.IO
open System.Collections.Generic
open Tools
open Mono.Cecil

let assemblyRefsByPlatform = Dictionary<TargetFramework,HashSet<string*string>>()


let clean path =
  printfn "Cleaning %s." path
  if path |> Directory.Exists then
      path 
       |> Directory.GetFiles
       |> Array.map (fun x -> printfn "Delete file %s." x; x)
       |> Array.iter File.Delete

      path 
       |> Directory.GetDirectories
       |> Array.map (fun x -> printfn "Delete Dir %s." x; x)
       |> Array.iter (fun x->Directory.Delete(x, recursive = true))

let generate () = 
  let br = System.Environment.NewLine
  let header  = sprintf "// Generated with %s (%s) %s" projectName versionPrefix projectUrl


  let queryHeader = header + br + br

  for target in projectTargets do
    printfn "Generating Source for %A" target

    let sysfull = systemTargetInfo target
                      |> systemDllsResolver

    let targetDir = Path.Combine(srcDir, sprintf "%A" target)

    Directory.CreateDirectory targetDir |> ignore
    let assemblyRef = HashSet<string * string>()
    let generateWrapper nsp nm refunc idfun =
            let results = Generate.writeWrappers header targetDir sysfull nsp nm refunc idfun
            for r in results do
                assemblyRef.Add(r.Name.Name, r.Name.Version.ToString()) |> ignore
    let generateQueryWrapper nsp nm refunc idfun = 
            let results = Generate.writeWrappers queryHeader targetDir sysfull nsp nm refunc idfun
            for r in results do
                assemblyRef.Add(r.Name.Name, r.Name.Version.ToString()) |> ignore

    generateWrapper "System.Linq" "Enumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]
    generateWrapper "System.Linq" "ParallelEnumerable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]

    match target with
      | NET35 -> ()
      | _ -> generateQueryWrapper "System.Linq" "Queryable" Reorder.extensionMethodReorder [IdentifyMethods.isExtensionMethod]

    let stringMethodFilters = [
                                IdentifyMethods.matchesSignature Static "Join" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                                IdentifyMethods.matchesName Static "IsNullOrWhiteSpace"
                                IdentifyMethods.matchesName Static "IsNullOrEmpty"
                                IdentifyMethods.matchesName Static "Equals"
                                IdentifyMethods.matchesSignature Instance "Replace" ["System.String";"System.String"]
                                IdentifyMethods.matchesSignature Instance "Split" ["System.Char"]
                                IdentifyMethods.matchesSignature Instance "Split" ["System.Char[]"]
                                IdentifyMethods.matchesNames Instance ["StartsWith"; "Substring"; "Contains"; "EndsWith"; "Trim"; "TrimStart"; "TrimEnd"; "ToLower"; "ToUpper"; "PadRight"; "PadLeft"]
                                ]

    let stringReorder (m:MethodDefinition)  =
      if m.Name = "Equals" then
        Reorder.moveOneParamToEnd m
      else
        Reorder.noChange m

    generateWrapper "System" "String" stringReorder stringMethodFilters


    let dateTimeMethodFilters = [
                                IdentifyMethods.matchesNames Instance ["Add"; "AddDays"; "AddHours"; 
                                    "AddMilliSeconds"; "AddMinutes"; "AddMonths"; "AddSeconds"; "AddTicks"; 
                                    "ToShortDateString"; "ToShortTimeString"; "ToUniversalTime"]
                                ]

    generateWrapper "System" "DateTime" Reorder.noChange dateTimeMethodFilters


    let fileMethodFilters = [
                              IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                              IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>";"System.Text.Encoding"]
                              IdentifyMethods.matchesName Static "AppendAllLines"
                              ]

    let reorderForFile = Reorder.moveTypeToTheEnd "System.Collections.Generic.IEnumerable`1<System.String>"
    generateWrapper "System.IO" "File" reorderForFile fileMethodFilters



    let reorderForPath (m:MethodDefinition) = 
                            if m.Name = "Combine" then
                                m.Parameters |> Seq.rev
                            else
                                Reorder.moveNameToTheEnd "path" m

    generateWrapper "System.IO" "Path" reorderForPath [
           IdentifyMethods.matchesSignature Static "Combine" ["System.String";"System.String"]
           IdentifyMethods.matchesNames Static ["ChangeExtension";"GetDirectoryName";"GetExtension";
                                                  "GetFileName"; "GetDirectoryName"; "GetRelativePath";
                                                  "HasExtension"
                                                   ]
        ]

    generateWrapper "System.Collections.Generic" "Comparer" Reorder.noChange [IdentifyMethods.matchesName Static "Create"]
    generateWrapper "System.Collections.Generic" "EqualityComparer" Reorder.noChange [IdentifyMethods.matchesName Static "Default"]


    let regexReorder (m:Mono.Cecil.MethodDefinition) =
        let ps = m.Parameters
        if (ps |> Seq.length) > 1 && (ps |> Seq.head).Name = "input" then
            Seq.append (ps |> Seq.skip 1) (ps |> Seq.take 1)
        else
            upcast ps

    let regexMethodFilter =
      [
        IdentifyMethods.matchesName Static "IsMatch"
        IdentifyMethods.matchesName Static "Match"
        IdentifyMethods.matchesName Static "Matches"
        IdentifyMethods.matchesName Static "Replace"
        IdentifyMethods.matchesName Static "Split"
      ]

    generateWrapper "System.Text.RegularExpressions" "Regex" regexReorder regexMethodFilter


    assemblyRefsByPlatform.Add(target, assemblyRef)


  
