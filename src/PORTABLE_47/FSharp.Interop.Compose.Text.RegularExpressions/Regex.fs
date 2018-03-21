// Generated with FSharp.Interop.Compose (2.0.1) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.Text.RegularExpressions
/// Corresponding static methods as functions for [`System.Text.RegularExpressions.Regex`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex)
module Regex =

    /// Calls [`IsMatch(input, pattern)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch)
    let inline isMatch (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.IsMatch(input, pattern)

    /// Calls [`Match(input, pattern)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.match)
    let inline ``match`` (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Match(input, pattern)

    /// Calls [`Matches(input, pattern)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.matches)
    let inline matches (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Matches(input, pattern)

    /// Calls [`Replace(input, pattern, System.Text.RegularExpressions.MatchEvaluator(evaluator))`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.replace)
    let inline replace (pattern:System.String) (evaluator:System.Text.RegularExpressions.Match->System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Replace(input, pattern, System.Text.RegularExpressions.MatchEvaluator(evaluator))

    /// Calls [`Split(input, pattern)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.split)
    let inline split (pattern:System.String) (input:System.String) = System.Text.RegularExpressions.Regex.Split(input, pattern)

    /// Longer parameter versions of `System.Text.RegularExpressions.Regex` methods
    module Full =

        /// Calls [`IsMatch(input, pattern, options)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch)
        let inline isMatch pattern options input = System.Text.RegularExpressions.Regex.IsMatch(input, pattern, options)

        /// Calls [`Match(input, pattern, options)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.match)
        let inline ``match`` (pattern:System.String) (options:System.Text.RegularExpressions.RegexOptions) (input:System.String) = System.Text.RegularExpressions.Regex.Match(input, pattern, options)

        /// Calls [`Matches(input, pattern, options)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.matches)
        let inline matches pattern options input = System.Text.RegularExpressions.Regex.Matches(input, pattern, options)

        /// Calls [`Replace(input, pattern, replacement, options)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.replace)
        let inline replace (pattern:System.String) (replacement:System.String) (options:System.Text.RegularExpressions.RegexOptions) (input:System.String) = System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement, options)

        /// Calls [`Split(input, pattern, options)`](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.split)
        let inline split (pattern:System.String) (options:System.Text.RegularExpressions.RegexOptions) (input:System.String) = System.Text.RegularExpressions.Regex.Split(input, pattern, options)
