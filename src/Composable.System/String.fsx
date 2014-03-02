// Generated with ComposableExtensions (0.9.0) http://jbtule.github.io/ComposableExtensions

namespace Composable.System
/// Corresponding `System.String` static methods as functions
module String =

    /// Calls `Contains(value)`
    let inline contains value (``{instance}``:System.String) = ``{instance}``.Contains(value)

    /// Calls `EndsWith(value)`
    let inline endsWith value (``{instance}``:System.String) = ``{instance}``.EndsWith(value)

    /// Calls `IsNullOrEmpty(value)`
    let inline isNullOrEmpty value = System.String.IsNullOrEmpty(value)

    /// Calls `IsNullOrWhiteSpace(value)`
    let inline isNullOrWhiteSpace value = System.String.IsNullOrWhiteSpace(value)

    /// Calls `Join(separator, values)`
    let inline join (separator:System.String) (values:System.Collections.Generic.IEnumerable<System.String>) = System.String.Join(separator, values)

    /// Calls `PadLeft(totalWidth)`
    let inline padLeft totalWidth (``{instance}``:System.String) = ``{instance}``.PadLeft(totalWidth)

    /// Calls `PadRight(totalWidth)`
    let inline padRight totalWidth (``{instance}``:System.String) = ``{instance}``.PadRight(totalWidth)

    /// Calls `Replace(oldValue, newValue)`
    let inline replace (oldValue:System.String) (newValue:System.String) (``{instance}``:System.String) = ``{instance}``.Replace(oldValue, newValue)

    /// Calls `Split(separator)`
    let inline split separator (``{instance}``:System.String) = ``{instance}``.Split(separator)

    /// Calls `StartsWith(value)`
    let inline startsWith value (``{instance}``:System.String) = ``{instance}``.StartsWith(value)

    /// Calls `ToLower()`
    let inline toLower  (``{instance}``:System.String) = ``{instance}``.ToLower()

    /// Calls `ToUpper()`
    let inline toUpper  (``{instance}``:System.String) = ``{instance}``.ToUpper()

    /// Calls `Trim()`
    let inline trim  (``{instance}``:System.String) = ``{instance}``.Trim()

    /// Calls `TrimEnd(trimChars)`
    let inline trimEnd trimChars (``{instance}``:System.String) = ``{instance}``.TrimEnd(trimChars)

    /// Calls `TrimStart(trimChars)`
    let inline trimStart trimChars (``{instance}``:System.String) = ``{instance}``.TrimStart(trimChars)

    /// Longer parameter versions of `System.String` methods
    module Full =

        /// Calls `EndsWith(value, ignoreCase, culture)`
        let inline endsWith value ignoreCase culture (``{instance}``:System.String) = ``{instance}``.EndsWith(value, ignoreCase, culture)

        /// Calls `PadLeft(totalWidth, paddingChar)`
        let inline padLeft totalWidth paddingChar (``{instance}``:System.String) = ``{instance}``.PadLeft(totalWidth, paddingChar)

        /// Calls `PadRight(totalWidth, paddingChar)`
        let inline padRight totalWidth paddingChar (``{instance}``:System.String) = ``{instance}``.PadRight(totalWidth, paddingChar)

        /// Calls `Replace(oldValue, newValue)`
        let inline replace (oldValue:System.String) (newValue:System.String) (``{instance}``:System.Text.StringBuilder) = ``{instance}``.Replace(oldValue, newValue)

        /// Calls `StartsWith(value, ignoreCase, culture)`
        let inline startsWith value ignoreCase culture (``{instance}``:System.String) = ``{instance}``.StartsWith(value, ignoreCase, culture)

        /// Calls `ToLower(culture)`
        let inline toLower culture (``{instance}``:System.String) = ``{instance}``.ToLower(culture)

        /// Calls `ToUpper(culture)`
        let inline toUpper culture (``{instance}``:System.String) = ``{instance}``.ToUpper(culture)

        /// Calls `Trim(trimChars)`
        let inline trim trimChars (``{instance}``:System.String) = ``{instance}``.Trim(trimChars)
