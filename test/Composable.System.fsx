namespace Test.Composable.System

#load "includes.fsx"

open Xunit
open FsUnit.Xunit
open Composable.System

module String =

    [<Fact>]
    let contains () =
        "hello" |> String.contains "ll" |> should be True
        "hello" |> String.contains "z" |> should be False


    [<Fact>]
    let endsWith () =
        "hello" |> String.endsWith "lo" |> should be True
        "hello" |> String.endsWith "he" |> should be False

#if TEST_PORTABLE_47 || TEST_PORTABLE_259
    [<Fact>]
    let endsWithFull () =
        "HELLO"
            |> String.Full.endsWith "lo" System.StringComparison.InvariantCultureIgnoreCase
            |> should be True
#else
    [<Fact>]
    let endsWithFull () =
        "HELLO"
            |> String.Full.endsWith "lo" true System.Globalization.CultureInfo.InvariantCulture
            |> should be True
#endif

#if NET35
#else

    [<Fact>]
    let isNullOrWhitespace () =
        ["1";"";"2";"  "; "3"; null; "4"]
           |> Seq.filter (not << String.isNullOrWhiteSpace)
           |> Seq.toList
           |> should equal ["1";"2";"3";"4"]

#endif

    [<Fact>]
    let isNullOrEmpty() =
        ["1";"";"2";"  "; "3"; null; "4"]
           |> Seq.filter (not << String.isNullOrEmpty)
           |> Seq.toList
           |> should equal ["1";"2";"  ";"3";"4"]

#if NET35
#else

    [<Fact>]
    let join () =
        ["1";"2";"3"] |> String.join " " |> should equal "1 2 3"

#endif

    [<Fact>]
    let padLeft () =
        "hello" |> String.padLeft 6 |> should equal " hello"

    [<Fact>]
    let padLeftFull () =
        "1" |> String.Full.padLeft 3 '0' |> should equal "001"

    [<Fact>]
    let padRight () =
        "hello" |> String.padRight 6 |> should equal "hello "

    [<Fact>]
    let padRightFull () =
        "1" |> String.Full.padRight 3 '0' |> should equal "100"

    [<Fact>]
    let replace () =
        "hello what"
            |> String.replace "what" "world"
            |> should equal "hello world"

    [<Fact>]
    let split () =
        "one,two,three"
            |> String.split [|','|]
            |> Seq.toList
            |> should equal ["one";"two";"three"]

    [<Fact>]
    let startsWith () =
        ["One";"Two";"Three"]
           |> Seq.filter (String.startsWith "T")
           |> Seq.toList
           |> should equal ["Two";"Three"]

    [<Fact>]
    let substring () =
        "one two three"
           |> String.substring 4
           |> should equal "two three"

    [<Fact>]
    let substringFull () =
        "one two three"
           |> String.Full.substring 4 3
           |> should equal "two"

#if TEST_PORTABLE_47 || TEST_PORTABLE_259
    [<Fact>]
    let startsWithFull () =
        ["One";"Two";"Three"]
           |> Seq.filter (String.Full.startsWith "t" System.StringComparison.InvariantCultureIgnoreCase)
           |> Seq.toList
           |> should equal ["Two";"Three"]
#else
    [<Fact>]
    let startsWithFull () =
        ["One";"Two";"Three"]
           |> Seq.filter (String.Full.startsWith "t" true System.Globalization.CultureInfo.InvariantCulture)
           |> Seq.toList
           |> should equal ["Two";"Three"]

    [<Fact>]
    let toLowerFull () =
        "LOWER" |> String.Full.toLower System.Globalization.CultureInfo.InvariantCulture |> should equal "lower"

    [<Fact>]
    let toUpperFull () =
        "upper" |> String.Full.toUpper System.Globalization.CultureInfo.InvariantCulture |> should equal "UPPER"

#endif


    [<Fact>]
    let toLower () =
        "LOWER" |> String.toLower |> should equal "lower"

    [<Fact>]
    let toUpper () =
        "upper" |> String.toUpper |> should equal "UPPER"

    [<Fact>]
    let trim () =
        " hello " |> String.trim |> should equal "hello"

    [<Fact>]
    let trimFull () =
        "00100" |> String.Full.trim [|'0'|] |> should equal "1"

    [<Fact>]
    let trimStart () =
        " hello " |> String.trimStart [|' '|] |> should equal "hello "

    [<Fact>]
    let trimEnd () =
        " hello " |> String.trimEnd [|' '|] |> should equal " hello"
