// Generated with ComposableExtensions (0.7.1) https://github.com/jbtule/ComposableExtensions

module Composable.System.String
let inline isNullOrEmpty value = System.String.IsNullOrEmpty(value)
let inline isNullOrWhiteSpace value = System.String.IsNullOrWhiteSpace(value)
let inline join (separator:System.String) (values:System.Collections.Generic.IEnumerable<System.String>) = System.String.Join(separator, values)
