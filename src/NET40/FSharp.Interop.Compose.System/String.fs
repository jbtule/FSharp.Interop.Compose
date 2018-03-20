// Generated with FSharp.Interop.Compose (1.14.0) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.System
/// Corresponding static methods as functions for [`System.String`](https://docs.microsoft.com/en-us/dotnet/api/system.string)
module String =

    /// Calls [`Contains(value)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.contains)
    let inline contains value (``{instance}``:System.String) = ``{instance}``.Contains(value)

    /// Calls [`EndsWith(value)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.endswith)
    let inline endsWith value (``{instance}``:System.String) = ``{instance}``.EndsWith(value)

    /// Calls [`Equals(a, b)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.equals)
    let inline equals (b:System.String) (a:System.String) = System.String.Equals(a, b)

    /// Calls [`IsNullOrEmpty(value)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.isnullorempty)
    let inline isNullOrEmpty value = System.String.IsNullOrEmpty(value)

    /// Calls [`IsNullOrWhiteSpace(value)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace)
    let inline isNullOrWhiteSpace value = System.String.IsNullOrWhiteSpace(value)

    /// Calls [`Join(separator, values)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.join)
    let inline join (separator:System.String) (values:System.Collections.Generic.IEnumerable<System.String>) = System.String.Join(separator, values)

    /// Calls [`PadLeft(totalWidth)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.padleft)
    let inline padLeft totalWidth (``{instance}``:System.String) = ``{instance}``.PadLeft(totalWidth)

    /// Calls [`PadRight(totalWidth)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.padright)
    let inline padRight totalWidth (``{instance}``:System.String) = ``{instance}``.PadRight(totalWidth)

    /// Calls [`Replace(oldValue, newValue)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.replace)
    let inline replace (oldValue:System.String) (newValue:System.String) (``{instance}``:System.String) = ``{instance}``.Replace(oldValue, newValue)

    /// Calls [`Split(separator)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.split)
    let inline split separator (``{instance}``:System.String) = ``{instance}``.Split(separator)

    /// Calls [`StartsWith(value)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.startswith)
    let inline startsWith value (``{instance}``:System.String) = ``{instance}``.StartsWith(value)

    /// Calls [`Substring(startIndex)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.substring)
    let inline substring startIndex (``{instance}``:System.String) = ``{instance}``.Substring(startIndex)

    /// Calls [`ToLower()`](https://docs.microsoft.com/en-us/dotnet/api/system.string.tolower)
    let inline toLower  (``{instance}``:System.String) = ``{instance}``.ToLower()

    /// Calls [`ToUpper()`](https://docs.microsoft.com/en-us/dotnet/api/system.string.toupper)
    let inline toUpper  (``{instance}``:System.String) = ``{instance}``.ToUpper()

    /// Calls [`Trim()`](https://docs.microsoft.com/en-us/dotnet/api/system.string.trim)
    let inline trim  (``{instance}``:System.String) = ``{instance}``.Trim()

    /// Calls [`TrimEnd(trimChars)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.trimend)
    let inline trimEnd trimChars (``{instance}``:System.String) = ``{instance}``.TrimEnd(trimChars)

    /// Calls [`TrimStart(trimChars)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.trimstart)
    let inline trimStart trimChars (``{instance}``:System.String) = ``{instance}``.TrimStart(trimChars)

    /// Longer parameter versions of `System.String` methods
    module Full =

        /// Calls [`EndsWith(value, ignoreCase, culture)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.endswith)
        let inline endsWith value ignoreCase culture (``{instance}``:System.String) = ``{instance}``.EndsWith(value, ignoreCase, culture)

        /// Calls [`Equals(a, b, comparisonType)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.equals)
        let inline equals b comparisonType a = System.String.Equals(a, b, comparisonType)

        /// Calls [`PadLeft(totalWidth, paddingChar)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.padleft)
        let inline padLeft totalWidth paddingChar (``{instance}``:System.String) = ``{instance}``.PadLeft(totalWidth, paddingChar)

        /// Calls [`PadRight(totalWidth, paddingChar)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.padright)
        let inline padRight totalWidth paddingChar (``{instance}``:System.String) = ``{instance}``.PadRight(totalWidth, paddingChar)

        /// Calls [`Split(separator)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.split)
        let inline split separator (``{instance}``:System.String) = ``{instance}``.Split(separator)

        /// Calls [`StartsWith(value, ignoreCase, culture)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.startswith)
        let inline startsWith value ignoreCase culture (``{instance}``:System.String) = ``{instance}``.StartsWith(value, ignoreCase, culture)

        /// Calls [`Substring(startIndex, length)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.substring)
        let inline substring startIndex length (``{instance}``:System.String) = ``{instance}``.Substring(startIndex, length)

        /// Calls [`ToLower(culture)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.tolower)
        let inline toLower culture (``{instance}``:System.String) = ``{instance}``.ToLower(culture)

        /// Calls [`ToUpper(culture)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.toupper)
        let inline toUpper culture (``{instance}``:System.String) = ``{instance}``.ToUpper(culture)

        /// Calls [`Trim(trimChars)`](https://docs.microsoft.com/en-us/dotnet/api/system.string.trim)
        let inline trim trimChars (``{instance}``:System.String) = ``{instance}``.Trim(trimChars)
