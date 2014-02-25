// Generated with ComposableExtensions (0.8.1) http://jbtule.github.io/ComposableExtensions

/// Corresponding `System.Linq.ParallelEnumerable` static methods as functions
module Composable.Linq.ParallelEnumerable

/// Calls `Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))`
let inline aggregate (func:'TSource->'TSource->'TSource) source = System.Linq.ParallelEnumerable.Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))

/// Calls `All(source, System.Func<'TSource, System.Boolean>(predicate))`
let inline all (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.All(source, System.Func<'TSource, System.Boolean>(predicate))

/// Calls `Any(source)`
let inline any source = System.Linq.ParallelEnumerable.Any(source)

/// Calls `AsEnumerable(source)`
let inline asEnumerable source = System.Linq.ParallelEnumerable.AsEnumerable(source)

/// Calls `AsSequential(source)`
let inline asSequential source = System.Linq.ParallelEnumerable.AsSequential(source)

/// Calls `AsUnordered(source)`
let inline asUnordered source = System.Linq.ParallelEnumerable.AsUnordered(source)

/// Calls `Cast<'TResult>(source)`
let inline cast<'TResult> source = System.Linq.ParallelEnumerable.Cast<'TResult>(source)

/// Calls `Contains(source, value)`
let inline contains value source = System.Linq.ParallelEnumerable.Contains(source, value)

/// Calls `Count(source)`
let inline count source = System.Linq.ParallelEnumerable.Count(source)

/// Calls `DefaultIfEmpty(source)`
let inline defaultIfEmpty source = System.Linq.ParallelEnumerable.DefaultIfEmpty(source)

/// Calls `Distinct(source)`
let inline distinct source = System.Linq.ParallelEnumerable.Distinct(source)

/// Calls `ElementAt(source, index)`
let inline elementAt index source = System.Linq.ParallelEnumerable.ElementAt(source, index)

/// Calls `ElementAtOrDefault(source, index)`
let inline elementAtOrDefault index source = System.Linq.ParallelEnumerable.ElementAtOrDefault(source, index)

/// Calls `First(source)`
let inline first source = System.Linq.ParallelEnumerable.First(source)

/// Calls `FirstOrDefault(source)`
let inline firstOrDefault source = System.Linq.ParallelEnumerable.FirstOrDefault(source)

/// Calls `ForAll(source, action)`
let inline forAll action source = System.Linq.ParallelEnumerable.ForAll(source, action)

/// Calls `GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline groupBy (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `Last(source)`
let inline last source = System.Linq.ParallelEnumerable.Last(source)

/// Calls `LastOrDefault(source)`
let inline lastOrDefault source = System.Linq.ParallelEnumerable.LastOrDefault(source)

/// Calls `LongCount(source)`
let inline longCount source = System.Linq.ParallelEnumerable.LongCount(source)

/// Calls `OfType<'TResult>(source)`
let inline ofType<'TResult> source = System.Linq.ParallelEnumerable.OfType<'TResult>(source)

/// Calls `OrderBy(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline orderBy (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.OrderBy(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline orderByDescending (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `Reverse(source)`
let inline reverse source = System.Linq.ParallelEnumerable.Reverse(source)

/// Calls `Single(source)`
let inline single source = System.Linq.ParallelEnumerable.Single(source)

/// Calls `SingleOrDefault(source)`
let inline singleOrDefault source = System.Linq.ParallelEnumerable.SingleOrDefault(source)

/// Calls `Skip(source, count)`
let inline skip count source = System.Linq.ParallelEnumerable.Skip(source, count)

/// Calls `Take(source, count)`
let inline take count source = System.Linq.ParallelEnumerable.Take(source, count)

/// Calls `ThenBy(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline thenBy (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline thenByDescending (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `ToArray(source)`
let inline toArray source = System.Linq.ParallelEnumerable.ToArray(source)

/// Calls `ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline toDictionary (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `ToList(source)`
let inline toList source = System.Linq.ParallelEnumerable.ToList(source)

/// Calls `ToLookup(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline toLookup (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ToLookup(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `WithCancellation(source, cancellationToken)`
let inline withCancellation cancellationToken source = System.Linq.ParallelEnumerable.WithCancellation(source, cancellationToken)

/// Calls `WithDegreeOfParallelism(source, degreeOfParallelism)`
let inline withDegreeOfParallelism degreeOfParallelism source = System.Linq.ParallelEnumerable.WithDegreeOfParallelism(source, degreeOfParallelism)

/// Calls `WithExecutionMode(source, executionMode)`
let inline withExecutionMode executionMode source = System.Linq.ParallelEnumerable.WithExecutionMode(source, executionMode)

/// Calls `WithMergeOptions(source, mergeOptions)`
let inline withMergeOptions mergeOptions source = System.Linq.ParallelEnumerable.WithMergeOptions(source, mergeOptions)

/// Longer parameter versions of `System.Linq.ParallelEnumerable` methods
module Full =

    /// Calls `Aggregate(source, seed, System.Func<'TAccumulate, 'TSource, 'TAccumulate>(func), System.Func<'TAccumulate, 'TResult>(resultSelector))`
    let inline aggregate (seed:'TAccumulate) (func:'TAccumulate->'TSource->'TAccumulate) (resultSelector:'TAccumulate->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Aggregate(source, seed, System.Func<'TAccumulate, 'TSource, 'TAccumulate>(func), System.Func<'TAccumulate, 'TResult>(resultSelector))

    /// Calls `Any(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline any (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Any(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `Contains(source, value, comparer)`
    let inline contains value comparer source = System.Linq.ParallelEnumerable.Contains(source, value, comparer)

    /// Calls `Count(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline count (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Count(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `DefaultIfEmpty(source, defaultValue)`
    let inline defaultIfEmpty defaultValue source = System.Linq.ParallelEnumerable.DefaultIfEmpty(source, defaultValue)

    /// Calls `Distinct(source, comparer)`
    let inline distinct comparer source = System.Linq.ParallelEnumerable.Distinct(source, comparer)

    /// Calls `First(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline first (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.First(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline firstOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)`
    let inline groupBy (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) (resultSelector:'TKey->System.Collections.Generic.IEnumerable<'TElement>->'TResult) comparer source = System.Linq.ParallelEnumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)

    /// Calls `Last(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline last (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Last(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `LastOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline lastOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.LastOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `LongCount(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline longCount (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.LongCount(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `OrderBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline orderBy (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.OrderBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline orderByDescending (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `Single(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline single (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Single(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline singleOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline thenBy (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline thenByDescending (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`
    let inline toDictionary (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.ParallelEnumerable.ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)

    /// Calls `ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`
    let inline toLookup (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.ParallelEnumerable.ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)
