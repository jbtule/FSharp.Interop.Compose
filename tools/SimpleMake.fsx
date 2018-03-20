#load "CompilerHelper.fsx"
#load "Vars.fsx"
#load "Generate.fsx"
#load "Docs.fsx"

open System.IO
open System.Collections.Generic
open Tools

let assemblyRefsByPlatform = Dictionary<TargetFramework,HashSet<string*string>>()


let clean path =
  printfn "Cleaning %s." path

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
  let header  = sprintf "// Generated with %s (%s) %s" projectName version projectUrl


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
                                IdentifyMethods.matchesSignature Instance "Replace" ["System.String";"System.String"]
                                IdentifyMethods.matchesSignature Instance "Split" ["System.Char"]
                                IdentifyMethods.matchesSignature Instance "Split" ["System.Char[]"]
                                IdentifyMethods.matchesNames Instance ["StartsWith"; "Substring"; "Contains"; "EndsWith"; "Trim"; "TrimStart"; "TrimEnd"; "ToLower"; "ToUpper"; "PadRight"; "PadLeft"]
                                ]

    generateWrapper "System" "String" Reorder.noChange stringMethodFilters

    let fileMethodFilters = [
                              IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>"]
                              IdentifyMethods.matchesSignature Static "WriteAllLines" ["System.String";"System.Collections.Generic.IEnumerable`1<System.String>";"System.Text.Encoding"]
                              IdentifyMethods.matchesName Static "AppendAllLines"
                              ]

    let reorderForFile = Reorder.moveTypeToTheEnd "System.Collections.Generic.IEnumerable`1<System.String>"
    generateWrapper "System.IO" "File" reorderForFile fileMethodFilters


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


  
