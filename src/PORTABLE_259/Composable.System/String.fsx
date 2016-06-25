// Generated with ComposableExtensions (0.13.0) http://jbtule.github.io/ComposableExtensions

namespace Composable.System
/// Corresponding static methods as functions for [`System.String`](http://msdn.microsoft.com/en-us/library/system.string)
module String =

    /// Calls [`Contains(value)`](http://msdn.microsoft.com/en-us/library/system.string.contains)
    let inline contains value (``{instance}``:System.String) = ``{instance}``.Contains(value)

    /// Calls [`EndsWith(value)`](http://msdn.microsoft.com/en-us/library/system.string.endswith)
    let inline endsWith value (``{instance}``:System.String) = ``{instance}``.EndsWith(value)

    /// Calls [`IsNullOrEmpty(value)`](http://msdn.microsoft.com/en-us/library/system.string.isnullorempty)
    let inline isNullOrEmpty value = System.String.IsNullOrEmpty(value)

    /// Calls [`IsNullOrWhiteSpace(value)`](http://msdn.microsoft.com/en-us/library/system.string.isnullorwhitespace)
    let inline isNullOrWhiteSpace value = System.String.IsNullOrWhiteSpace(value)

    /// Calls [`Join(separator, values)`](http://msdn.microsoft.com/en-us/library/system.string.join)
    let inline join (separator:System.String) (values:System.Collections.Generic.IEnumerable<System.String>) = System.String.Join(separator, values)

    /// Calls [`PadLeft(totalWidth)`](http://msdn.microsoft.com/en-us/library/system.string.padleft)
    let inline padLeft totalWidth (``{instance}``:System.String) = ``{instance}``.PadLeft(totalWidth)

    /// Calls [`PadRight(totalWidth)`](http://msdn.microsoft.com/en-us/library/system.string.padright)
    let inline padRight totalWidth (``{instance}``:System.String) = ``{instance}``.PadRight(totalWidth)

    /// Calls [`Replace(oldValue, newValue)`](http://msdn.microsoft.com/en-us/library/system.string.replace)
    let inline replace (oldValue:System.String) (newValue:System.String) (``{instance}``:System.String) = ``{instance}``.Replace(oldValue, newValue)

    /// Calls [`Split(separator)`](http://msdn.microsoft.com/en-us/library/system.string.split)
    let inline split separator (``{instance}``:System.String) = ``{instance}``.Split(separator)

    /// Calls [`StartsWith(value)`](http://msdn.microsoft.com/en-us/library/system.string.startswith)
    let inline startsWith value (``{instance}``:System.String) = ``{instance}``.StartsWith(value)

    /// Calls [`Substring(startIndex)`](http://msdn.microsoft.com/en-us/library/system.string.substring)
    let inline substring startIndex (``{instance}``:System.String) = ``{instance}``.Substring(startIndex)

    /// Calls [`ToLower()`](http://msdn.microsoft.com/en-us/library/system.string.tolower)
    let inline toLower  (``{instance}``:System.String) = ``{instance}``.ToLower()

    /// Calls [`ToUpper()`](http://msdn.microsoft.com/en-us/library/system.string.toupper)
    let inline toUpper  (``{instance}``:System.String) = ``{instance}``.ToUpper()

    /// Calls [`Trim()`](http://msdn.microsoft.com/en-us/library/system.string.trim)
    let inline trim  (``{instance}``:System.String) = ``{instance}``.Trim()

    /// Calls [`TrimEnd(trimChars)`](http://msdn.microsoft.com/en-us/library/system.string.trimend)
    let inline trimEnd trimChars (``{instance}``:System.String) = ``{instance}``.TrimEnd(trimChars)

    /// Calls [`TrimStart(trimChars)`](http://msdn.microsoft.com/en-us/library/system.string.trimstart)
    let inline trimStart trimChars (``{instance}``:System.String) = ``{instance}``.TrimStart(trimChars)

    /// Longer parameter versions of `System.String` methods
    module Full =

        /// Calls [`EndsWith(value, comparisonType)`](http://msdn.microsoft.com/en-us/library/system.string.endswith)
        let inline endsWith value comparisonType (``{instance}``:System.String) = ``{instance}``.EndsWith(value, comparisonType)

        /// Calls [`PadLeft(totalWidth, paddingChar)`](http://msdn.microsoft.com/en-us/library/system.string.padleft)
        let inline padLeft totalWidth paddingChar (``{instance}``:System.String) = ``{instance}``.PadLeft(totalWidth, paddingChar)

        /// Calls [`PadRight(totalWidth, paddingChar)`](http://msdn.microsoft.com/en-us/library/system.string.padright)
        let inline padRight totalWidth paddingChar (``{instance}``:System.String) = ``{instance}``.PadRight(totalWidth, paddingChar)

        /// Calls [`Split(separator)`](http://msdn.microsoft.com/en-us/library/system.string.split)
        let inline split separator (``{instance}``:System.String) = ``{instance}``.Split(separator)

        /// Calls [`StartsWith(value, comparisonType)`](http://msdn.microsoft.com/en-us/library/system.string.startswith)
        let inline startsWith value comparisonType (``{instance}``:System.String) = ``{instance}``.StartsWith(value, comparisonType)

        /// Calls [`Substring(startIndex, length)`](http://msdn.microsoft.com/en-us/library/system.string.substring)
        let inline substring startIndex length (``{instance}``:System.String) = ``{instance}``.Substring(startIndex, length)

        /// Calls [`Trim(trimChars)`](http://msdn.microsoft.com/en-us/library/system.string.trim)
        let inline trim trimChars (``{instance}``:System.String) = ``{instance}``.Trim(trimChars)
