// Generated with ComposableExtensions (0.13.0) http://jbtule.github.io/ComposableExtensions

namespace Composable.Text.RegularExpressions
/// Corresponding static methods as functions for [`System.Text.RegularExpressions.Regex`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex)
module Regex =

    /// Calls [`IsMatch(input, pattern)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.ismatch)
    let inline isMatch (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.IsMatch(input, pattern)

    /// Calls [`Match(input, pattern)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.match)
    let inline ``match`` (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Match(input, pattern)

    /// Calls [`Matches(input, pattern)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.matches)
    let inline matches (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Matches(input, pattern)

    /// Calls [`Replace(input, pattern, System.Text.RegularExpressions.MatchEvaluator(evaluator))`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.replace)
    let inline replace (pattern:System.String) (evaluator:System.Text.RegularExpressions.Match->System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Replace(input, pattern, System.Text.RegularExpressions.MatchEvaluator(evaluator))

    /// Calls [`Split(input, pattern)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.split)
    let inline split (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Split(input, pattern)

    /// Longer parameter versions of `System.Text.RegularExpressions.Regex` methods
    module Full =

        /// Calls [`IsMatch(input, pattern, options)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.ismatch)
        let inline isMatch pattern options input = System.Text.RegularExpressions.Regex.IsMatch(input, pattern, options)

        /// Calls [`Match(input, pattern, options)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.match)
        let inline ``match`` (pattern:System.String) (options:System.Text.RegularExpressions.RegexOptions) (input:System.String) = System.Text.RegularExpressions.Regex.Match(input, pattern, options)

        /// Calls [`Matches(input, pattern, options)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.matches)
        let inline matches pattern options input = System.Text.RegularExpressions.Regex.Matches(input, pattern, options)

        /// Calls [`Replace(input, pattern, replacement, options)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.replace)
        let inline replace (pattern:System.String) (replacement:System.String) (options:System.Text.RegularExpressions.RegexOptions) (input:System.String) = System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement, options)

        /// Calls [`Split(input, pattern, options)`](http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.split)
        let inline split (pattern:System.String) (options:System.Text.RegularExpressions.RegexOptions) (input:System.String) = System.Text.RegularExpressions.Regex.Split(input, pattern, options)
