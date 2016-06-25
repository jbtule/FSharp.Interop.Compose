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

namespace Tools
#r "packages/Mono.Cecil/lib/net40/Mono.Cecil.dll"
#r "packages/FSharp.Compiler.Service/lib/net45/FSharp.Compiler.Service.dll"

open System.Reflection
open System.IO
open Mono.Cecil

type MethodContext =
    | Static
    | Instance

module internal Helpers =
    let hasNamePrefix (n:string) (typeOrMethodName:string) =
        let testBoundry =
            lazy
                let b = typeOrMethodName.Replace(n,"")
                b.Length = 0 || not (System.Char.IsLetterOrDigit(b.[0]))
        typeOrMethodName.StartsWith(n) && testBoundry.Value

module IdentifyMethods =

    let isPublicStaticMethod (x:MethodDefinition) = x.IsStatic && x.IsPublic

    let private hasAttribute (attrName:string) (x:IMemberDefinition) =
        x.HasCustomAttributes && x.CustomAttributes
            |> Seq.exists (fun a -> Helpers.hasNamePrefix attrName a.AttributeType.FullName)

    let private hasExtensionMember =
        hasAttribute "System.Runtime.CompilerServices.ExtensionAttribute"

    let private isObsoleteMember =
        hasAttribute "System.ObsoleteAttribute"

    let isExtensionMethod (x:MethodDefinition) = hasExtensionMember x

    let isObsoleteMethod (x:MethodDefinition) = isObsoleteMember x

    let matchesSignature (c:MethodContext) (name:string) (argTypes:string seq) (m:MethodDefinition) =
        let nameMatch =  m.Name = name && (m.IsStatic <> (c = Instance))
        let paramTypes = (m.Parameters |> Seq.map (fun p -> p.ParameterType.FullName))
        nameMatch
            && Seq.length argTypes = Seq.length paramTypes
            && (paramTypes,argTypes)
                ||> Seq.zip
                |> Seq.fold (fun acc (t1,t2) -> acc && t1 |> Helpers.hasNamePrefix t2) true

    let matchesName  (c:MethodContext)  (name:string) (m:MethodDefinition) =
        (m.IsStatic <> (c = Instance)) && m.Name = name

    let matchesNames (c:MethodContext) (names:string seq) (m:MethodDefinition) =
        (m.IsStatic <> (c = Instance)) && names |> Seq.exists (fun n -> m.Name = n)

module Reformat =

    let private keywordSet = 
        Set([
            "abstract";"and";"as";"assert";"asr"
            "base";"begin";"class"; "const" ;"default"
            "delegate"; "do"; "done" ;"downcast"
            "downto"     ;  "elif"       ;  "else"       ;  "end"        ;  "exception"  ;  "extern"     ;  "false"      ;  "finally"    ;
            "for"        ;  "fun"        ;  "function"   ;  "global"     ;  "if"         ;  "in"         ;  "inherit"    ;  "inline"     ;
            "interface"  ;  "internal"   ;  "land"       ;  "lazy"       ;  "let"        ;  "lor"        ;  "lsl"        ;  "lsr"        ;  "lxor"       ;  "match"      ;
            "member"     ;  "mod"        ;  "module"     ;  "mutable"    ;  "namespace"  ;  "new"        ;  "null"       ;  "of"         ;
            "open"       ;  "or"         ;  "override"   ;  "private"    ;  "public"     ;  "rec"        ;  "return"     ;  "sig"        ;  "static"     ;  "struct"     ;
            "then"       ;  "to"         ;  "true"       ;  "try"        ;  "type"       ;  "upcast"     ;  "use"        ;  "val"        ;
            "void"       ;  "when"       ;  "while"      ;  "with"       ;  "yield"
            "_" ;      "atomic"; "break";"checked" ;"component"; "constraint"; "constructor"; "continue"; 
            "eager";"fixed"; "fori"; "functor";"include";            
            "measure"; "method"; "mixin";       "object"; 
            "parallel"; "params";  "process"; "protected"; "pure"; 
            "recursive";"sealed"; "trait";  "tailcall"; "virtual"; "volatile"
        ])

    let camelCase (x:string) = System.String.Join("", System.Char.ToLower(x.[0])::(x |> Seq.skip 1 |> Seq.toList))

    let slimGenericName x = System.Text.RegularExpressions.Regex.Replace(x, "`\d+", "")

    let private wrapKeywords (s:string) = if keywordSet.Contains(s) then "``" + s + "``" else s

    let docNameMethod (m:MethodDefinition) =
        sprintf "%s.%s"
            ((slimGenericName m.DeclaringType.FullName).ToLower())
            ((slimGenericName m.Name).ToLower())

    let (|CSharpFunc|CSharpExpr|CSharpOther|) (x:TypeReference) =
        let rType = x.Resolve()
        if rType <> null
              && rType.BaseType <> null
              && rType.BaseType.FullName |> Helpers.hasNamePrefix "System.MulticastDelegate"  then
            CSharpFunc
        elif x.FullName |> Helpers.hasNamePrefix "System.Func" then //PCL_47
            CSharpFunc
        elif x.FullName |> Helpers.hasNamePrefix "System.Linq.Expressions.Expression" then
            CSharpExpr
        else
            CSharpOther

    let private getGenericParameters (x:TypeReference) =
        (x :?> GenericInstanceType).GenericArguments

    let private getFuncParameters (x:TypeReference) =
        let rType = x.Resolve()
        if rType = null then //PCL_47
          (x :?> GenericInstanceType).GenericArguments |> Seq.toList
        else
          let pList = if x.IsGenericInstance then
                          (rType.GenericParameters |> Seq.map (fun g->g.Name), (x :?> GenericInstanceType).GenericArguments)
                              ||> Seq.zip
                              |> Seq.toList
                      else
                          List.empty
          let fullList = List.append pList ["Void", TypeReference("Microsoft.FSharp.Core","unit", null, null)]
          let fullMap = fullList |> Map.ofList

          let resolveParamType (p:TypeReference) =
              match fullMap |> Map.tryFind p.Name with
                | Some(mType) -> mType
                | None        -> p

          let invoke = x.Resolve().Methods |> Seq.find (fun m -> m.Name = "Invoke")
          (invoke.Parameters |> Seq.map (fun p->p.ParameterType) |> Seq.map resolveParamType |> Seq.cast<TypeReference> |> Seq.toList)
              @ [resolveParamType invoke.ReturnType]

    let rec typeNameFixer forFSharp (x:TypeReference) =
        let appendUnitWhenSingle (argNames:string seq) =
            if argNames |> Seq.length = 1 then Seq.append ["unit"] argNames else argNames
        let typeNameFix = typeNameFixer forFSharp
        let (|GenericType|FSharpFunc|FSharpQuote|ParameterName|PlainType|) (tr:TypeReference) =
            if tr.IsGenericInstance then
                if not forFSharp then
                    GenericType
                else
                    match tr with
                        | CSharpFunc -> FSharpFunc
                        | CSharpExpr -> FSharpQuote
                        | __________ -> GenericType
            elif tr.IsGenericParameter then
                ParameterName
            else
                let baseType (t:TypeReference) = (t :?> TypeDefinition).BaseType
                if forFSharp
                      && tr.IsDefinition
                      && baseType tr <> null
                      && (baseType tr).FullName |> Helpers.hasNamePrefix "System.MulticastDelegate"  then
                    FSharpFunc
                else
                    PlainType

        match x with
            | GenericType   ->
                sprintf "%s.%s<%s>"
                    x.Namespace
                    (slimGenericName x.Name)
                    (x |> getGenericParameters |> Seq.map typeNameFix |> String.concat ", ")
            | FSharpQuote   -> x
                                |> getGenericParameters
                                |> Seq.head
                                |> getGenericParameters
                                |> Seq.map typeNameFix
                                |> appendUnitWhenSingle
                                |> String.concat "->"
                                |> sprintf "Quotations.Expr<%s>"
            | FSharpFunc    -> x
                                |> getFuncParameters
                                |> Seq.map typeNameFix
                                |> appendUnitWhenSingle
                                |> String.concat "->"
            | ParameterName -> sprintf "'%s" x.Name
            | PlainType     -> sprintf "%s.%s" x.Namespace x.Name

    let parameterFixer (specifyAllTypes:bool) (x:ParameterDefinition) =
        let justName = wrapKeywords x.Name
        let fullDef = sprintf "(%s:%s)" justName (typeNameFixer true x.ParameterType)
        match x.ParameterType with
            | CSharpFunc
            | CSharpExpr -> fullDef
            | __________ -> if specifyAllTypes then fullDef else justName

    let private unwrapExpressionType (x:ParameterDefinition) =
        x.ParameterType |> getGenericParameters |> Seq.head

    let csharpCastFunc (x:ParameterDefinition) =
        match x.ParameterType with
            | CSharpFunc -> sprintf "%s(%s)" (typeNameFixer false x.ParameterType) x.Name
            | CSharpExpr -> sprintf "ComposableExtensions.Quotations.toExpression<%s>(%s)"
                                            (typeNameFixer false (unwrapExpressionType x)) x.Name
            | __________ -> x.Name

    let namespaceComposable (x:string) =
        if x.StartsWith("System") && x <> "System" then
            x.Replace("System", "Composable")
        else
            sprintf "Composable.%s" x

    let rec private matchesGenericParameter (matcher:GenericParameter) (t:TypeReference) =
        if t.IsGenericParameter then
            t.Name = matcher.Name
        elif t.IsGenericInstance then
            let g = t :?> GenericInstanceType
            let findMatch = matchesGenericParameter matcher
            g.GenericArguments |> Seq.exists findMatch
        else
            false

    let private matchesGenericParameters (matcher:GenericParameter) (plist:seq<TypeReference>) =
        let findMatch = matchesGenericParameter matcher
        plist |> Seq.exists findMatch

    let private fsGenParamName (p:GenericParameter) =
        (sprintf "'%s" p.Name)

    let private explictGenericParameters (x:MethodDefinition) =
        x.GenericParameters
            |> (fun p -> System.Linq.Enumerable.Reverse(p))
            |> Seq.fold (fun list p -> if matchesGenericParameters p (x.Parameters |> Seq.map (fun p->p.ParameterType)) then
                                            list
                                       else
                                            (sprintf "'%s" p.Name)::list) []

    let explictGenericParameterName (typeParams:GenericParameter seq) (changeName:string->string) (x:MethodDefinition) =
        let baseName = changeName x.Name
        let slist = (typeParams |> Seq.toList |> List.map fsGenParamName)
        let glist = if x.HasGenericParameters then
                        List.append slist (explictGenericParameters x)
                    else
                        slist
        if glist |> Seq.isEmpty then
            baseName
        else
            sprintf "%s<%s>" baseName (glist |> String.concat ", ")

    let private csharpTypeNameFixer (t:TypeDefinition) =
        if t.HasGenericParameters then
            sprintf "%s<%s>"
                (slimGenericName t.FullName)
                (t.GenericParameters |> Seq.map fsGenParamName |> String.concat ",")
        else
            t.FullName

    let methodWrapper (reorderedParameters:MethodDefinition->seq<ParameterDefinition>) (x:MethodDefinition) =
        let paramCnt = x.Parameters |> Seq.length
        let specifyAllTypes =
            x.DeclaringType.HasGenericParameters
            || (x.DeclaringType.Methods
                 |> Seq.filter (fun m-> m.IsPublic && m.Name = x.Name && (m.Parameters |> Seq.length) = paramCnt)
                 |> Seq.length) > 1
        let fsharpChange = camelCase >> wrapKeywords
        let fsharpName = explictGenericParameterName x.DeclaringType.GenericParameters fsharpChange x
        let csharpName = explictGenericParameterName [] (fun n->n) x
        let csharpType = csharpTypeNameFixer x.DeclaringType
        let parameterFix = parameterFixer specifyAllTypes
        let fsharpParams = (x |> reorderedParameters |> Seq.map parameterFix |> String.concat " ")
        let csharpParams = (x.Parameters |> Seq.map csharpCastFunc |> String.concat ", ")
        if x.IsStatic then
            sprintf "let inline %s %s = %s.%s(%s)" fsharpName fsharpParams csharpType csharpName csharpParams
        else
            sprintf "let inline %s %s (``{instance}``:%s) = ``{instance}``.%s(%s)"
                fsharpName fsharpParams csharpType csharpName csharpParams

module Reorder =
    let noChange (m:MethodDefinition) : seq<ParameterDefinition> = upcast m.Parameters

    let moveTypeToTheEnd (typeName:string) (m:MethodDefinition) : seq<ParameterDefinition> =
        m.Parameters
            |> Seq.mapi (fun i p -> (i,p))
            |> Seq.sortBy (fun (i,p)-> i + if p.ParameterType.FullName |> Helpers.hasNamePrefix typeName then 100 else 0)
            |> Seq.map (fun (_,p)-> p)

    let private equivalentTypes (t1:TypeReference) (t2:TypeReference) =
        let replaceName (t:GenericInstanceType) =
             t.GenericArguments |> Seq.fold (fun (acc:string) gp -> acc.Replace(gp.Name,"_")) t.FullName
        if t1.IsGenericInstance && t2.IsGenericInstance then
            (downcast t1 |> replaceName) = (downcast t2 |> replaceName )
        else
            t1.FullName = t2.FullName

    let private endsWithNumber = System.Text.RegularExpressions.Regex(@"^.*\d+$")


    let private identifyReorder2 (ps:ParameterDefinition seq) =
        let p1 = (ps |> Seq.item 0)
        let p2 = (ps |> Seq.item 1)

        equivalentTypes p1.ParameterType p2.ParameterType
            || endsWithNumber.IsMatch(p1.Name) && endsWithNumber.IsMatch(p2.Name)
            || p2.Name = "inner"
            || p2.Name = "second"

    let private fullmethodname (m:MethodDefinition) =
        sprintf "%s.%s.%s" m.DeclaringType.Namespace m.DeclaringType.Name m.Name

    let extensionMethodReorder (m:MethodDefinition) =
        let ps = m.Parameters
        let exceptions = ["System.Linq.Enumerable.Except";"System.Linq.Queryable.Except"]
        if (ps |> Seq.length) > 1
            && identifyReorder2 ps
            && exceptions |> Seq.exists (fun n-> (fullmethodname m) |> Helpers.hasNamePrefix n) |> not then
             Seq.append (ps |> Seq.skip 2) (ps |> Seq.take 2)
        else
             Seq.append (ps |> Seq.skip 1) (ps |> Seq.take 1)

module Generate =

    let writeWrappers
            (header:string)
            (srcDir:string)
            (asmPath:string list)
            (namesp:string)
            (typeName:string)
            (orderedParameters:MethodDefinition->seq<ParameterDefinition>)
            (methodSelectors:(MethodDefinition->bool) list) =

        if asmPath |> Seq.isEmpty then
            ()
        else

            let notObsolete = not << IdentifyMethods.isObsoleteMethod

            let methods = asmPath
                            |> Seq.map (fun p -> AssemblyDefinition.ReadAssembly(p))
                            |> Seq.collect (fun a -> a. MainModule.Types)
                            |> Seq.filter (fun t -> t.IsPublic)
                            |> Seq.filter (fun t -> t.Namespace |> Helpers.hasNamePrefix namesp)
                            |> Seq.filter (fun t -> t.Name |> Helpers.hasNamePrefix typeName)
                            |> Seq.collect (fun t -> t.Methods
                                                        |> Seq.filter (fun m -> m.IsPublic && (notObsolete m)))

            let chosenMethods =
                methodSelectors
                    |> Seq.fold (fun acc pred -> methods |> Seq.filter pred |> Seq.append acc) Seq.empty
                    |> Seq.distinct

            let removedMostOverloads = chosenMethods
                                        |> Seq.groupBy (fun m -> (m.Name,m.Parameters |> Seq.length))
                                        |> Seq.filter (fun (k,g) -> g |> Seq.length <= 2) //Skip over the numeric overloads
                                        |> Seq.collect (fun (k,g) -> g)

            let foldHighLowLists (minL:MethodDefinition list,maxL:MethodDefinition list)
                                 (minC:int, maxC:int, g:MethodDefinition seq) =
                let low = g |> Seq.find (fun m-> (m.Parameters |> Seq.length) = minC)
                let high = g |> Seq.toList |> List.rev |> Seq.find (fun m-> (m.Parameters |> Seq.length) = maxC)
                if low = high then
                    (low::minL, maxL)
                else
                    (low::minL, high::maxL)

            let main,full =
                removedMostOverloads
                    |> Seq.sortBy (fun m ->
                                         sprintf "%s(%s)%s(%s)"
                                            m.Name
                                            (m.Parameters |> Seq.map (fun p-> p.Name) |> String.concat ",")
                                            (if m.HasGenericParameters then " " else "~")
                                            (m.Parameters |> Seq.map (fun p-> p.ParameterType.FullName) |> String.concat ",")
                                    )
                    |> Seq.groupBy (fun m -> m.Name)
                    |> Seq.map (fun (k,g) -> (g |> Seq.map (fun m->Seq.length m.Parameters), g))
                    |> Seq.map (fun (c,g) -> (c |> Seq.min, c |> Seq.max, g))
                    |> Seq.fold foldHighLowLists (List.empty, List.empty)


            let list = [true,main;false,full]
            let nsp = Reformat.namespaceComposable namesp
            for (isMain, mlist) in list do
                if not (Seq.isEmpty mlist) then
                    let path = Path.Combine(srcDir, nsp)
                    Directory.CreateDirectory(path) |> ignore
                    use writer = System.IO.File.AppendText(Path.Combine(path, typeName+".fsx"))
                    if isMain then
                        writer.WriteLine(header)
                        writer.WriteLine()
                        writer.WriteLine(sprintf "namespace %s" nsp)
                        writer.WriteLine(sprintf "/// Corresponding static methods as functions for [`%s.%s`](http://msdn.microsoft.com/en-us/library/%s.%s)"
                                            namesp typeName (namesp.ToLower()) (typeName.ToLower()))
                        writer.WriteLine(sprintf "module %s =" typeName)
                    else
                        writer.WriteLine()
                        writer.Write(String.replicate 4 " ")
                        writer.WriteLine(sprintf "/// Longer parameter versions of `%s.%s` methods" namesp typeName)
                        writer.Write(String.replicate 4 " ")
                        writer.WriteLine("module Full =")
                    for m in mlist |> Seq.sortBy (fun x->x.Name) do
                        writer.WriteLine()
                        let csharpParams = (m.Parameters |> Seq.map Reformat.csharpCastFunc |> String.concat ", ")
                        writer.Write(String.replicate 4 " ")
                        if not isMain then
                            writer.Write(String.replicate 4 " ")
                        writer.WriteLine(sprintf "/// Calls [`%s(%s)`](http://msdn.microsoft.com/en-us/library/%s)"
                                            (Reformat.explictGenericParameterName [] (fun x->x) m)
                                            csharpParams
                                            (Reformat.docNameMethod m))
                        writer.Write(String.replicate 4 " ")
                        if not isMain then
                            writer.Write(String.replicate 4 " ")
                        writer.WriteLine(Reformat.methodWrapper orderedParameters m)
