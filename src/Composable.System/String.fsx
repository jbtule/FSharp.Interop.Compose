// Generated with ComposableExtensions (0.9.0) http://jbtule.github.io/ComposableExtensions

namespace Composable.System
/// Corresponding `System.String` static methods as functions
module String =

    /// Calls `IsNullOrEmpty(value)`
    let inline isNullOrEmpty value = System.String.IsNullOrEmpty(value)

    /// Calls `IsNullOrWhiteSpace(value)`
    let inline isNullOrWhiteSpace value = System.String.IsNullOrWhiteSpace(value)

    /// Calls `Join(separator, values)`
    let inline join (separator:System.String) (values:System.Collections.Generic.IEnumerable<System.String>) = System.String.Join(separator, values)
