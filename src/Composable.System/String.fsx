// Generated with ComposableExtensions (0.8.2) http://jbtule.github.io/ComposableExtensions

/// Corresponding `System.String` static methods as functions
module Composable.System.String

/// Calls `IsNullOrEmpty(value)`
let inline isNullOrEmpty value = System.String.IsNullOrEmpty(value)

/// Calls `IsNullOrWhiteSpace(value)`
let inline isNullOrWhiteSpace value = System.String.IsNullOrWhiteSpace(value)

/// Calls `Join(separator, values)`
let inline join (separator:System.String) (values:System.Collections.Generic.IEnumerable<System.String>) = System.String.Join(separator, values)
