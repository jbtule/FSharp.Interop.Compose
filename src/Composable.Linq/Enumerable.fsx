// Generated with ComposableExtensions (0.8.2) http://jbtule.github.io/ComposableExtensions

/// Corresponding `System.Linq.Enumerable` static methods as functions
module Composable.Linq.Enumerable

/// Calls `Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))`
let inline aggregate (func:'TSource->'TSource->'TSource) source = System.Linq.Enumerable.Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))

/// Calls `All(source, System.Func<'TSource, System.Boolean>(predicate))`
let inline all (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.All(source, System.Func<'TSource, System.Boolean>(predicate))

/// Calls `Any(source)`
let inline any source = System.Linq.Enumerable.Any(source)

/// Calls `AsEnumerable(source)`
let inline asEnumerable source = System.Linq.Enumerable.AsEnumerable(source)

/// Calls `Cast<'TResult>(source)`
let inline cast<'TResult> source = System.Linq.Enumerable.Cast<'TResult>(source)

/// Calls `Concat(first, second)`
let inline concat first second = System.Linq.Enumerable.Concat(first, second)

/// Calls `Contains(source, value)`
let inline contains value source = System.Linq.Enumerable.Contains(source, value)

/// Calls `Count(source)`
let inline count source = System.Linq.Enumerable.Count(source)

/// Calls `DefaultIfEmpty(source)`
let inline defaultIfEmpty source = System.Linq.Enumerable.DefaultIfEmpty(source)

/// Calls `Distinct(source)`
let inline distinct source = System.Linq.Enumerable.Distinct(source)

/// Calls `ElementAt(source, index)`
let inline elementAt index source = System.Linq.Enumerable.ElementAt(source, index)

/// Calls `ElementAtOrDefault(source, index)`
let inline elementAtOrDefault index source = System.Linq.Enumerable.ElementAtOrDefault(source, index)

/// Calls `Except(first, second)`
let inline except second first = System.Linq.Enumerable.Except(first, second)

/// Calls `First(source)`
let inline first source = System.Linq.Enumerable.First(source)

/// Calls `FirstOrDefault(source)`
let inline firstOrDefault source = System.Linq.Enumerable.FirstOrDefault(source)

/// Calls `GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline groupBy (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector))`
let inline groupJoin (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult) outer inner = System.Linq.Enumerable.GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector))

/// Calls `Intersect(first, second)`
let inline intersect first second = System.Linq.Enumerable.Intersect(first, second)

/// Calls `Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector))`
let inline join (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->'TInner->'TResult) outer inner = System.Linq.Enumerable.Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector))

/// Calls `Last(source)`
let inline last source = System.Linq.Enumerable.Last(source)

/// Calls `LastOrDefault(source)`
let inline lastOrDefault source = System.Linq.Enumerable.LastOrDefault(source)

/// Calls `LongCount(source)`
let inline longCount source = System.Linq.Enumerable.LongCount(source)

/// Calls `OfType<'TResult>(source)`
let inline ofType<'TResult> source = System.Linq.Enumerable.OfType<'TResult>(source)

/// Calls `OrderBy(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline orderBy (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.OrderBy(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline orderByDescending (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `Reverse(source)`
let inline reverse source = System.Linq.Enumerable.Reverse(source)

/// Calls `SequenceEqual(first, second)`
let inline sequenceEqual first second = System.Linq.Enumerable.SequenceEqual(first, second)

/// Calls `Single(source)`
let inline single source = System.Linq.Enumerable.Single(source)

/// Calls `SingleOrDefault(source)`
let inline singleOrDefault source = System.Linq.Enumerable.SingleOrDefault(source)

/// Calls `Skip(source, count)`
let inline skip count source = System.Linq.Enumerable.Skip(source, count)

/// Calls `Take(source, count)`
let inline take count source = System.Linq.Enumerable.Take(source, count)

/// Calls `ThenBy(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline thenBy (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline thenByDescending (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `ToArray(source)`
let inline toArray source = System.Linq.Enumerable.ToArray(source)

/// Calls `ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline toDictionary (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `ToList(source)`
let inline toList source = System.Linq.Enumerable.ToList(source)

/// Calls `ToLookup(source, System.Func<'TSource, 'TKey>(keySelector))`
let inline toLookup (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.ToLookup(source, System.Func<'TSource, 'TKey>(keySelector))

/// Calls `Union(first, second)`
let inline union first second = System.Linq.Enumerable.Union(first, second)

/// Calls `Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))`
let inline zip (resultSelector:'TFirst->'TSecond->'TResult) first second = System.Linq.Enumerable.Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))

/// Longer parameter versions of `System.Linq.Enumerable` methods
module Full =

    /// Calls `Aggregate(source, seed, System.Func<'TAccumulate, 'TSource, 'TAccumulate>(func), System.Func<'TAccumulate, 'TResult>(resultSelector))`
    let inline aggregate seed (func:'TAccumulate->'TSource->'TAccumulate) (resultSelector:'TAccumulate->'TResult) source = System.Linq.Enumerable.Aggregate(source, seed, System.Func<'TAccumulate, 'TSource, 'TAccumulate>(func), System.Func<'TAccumulate, 'TResult>(resultSelector))

    /// Calls `Any(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline any (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.Any(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `Contains(source, value, comparer)`
    let inline contains value comparer source = System.Linq.Enumerable.Contains(source, value, comparer)

    /// Calls `Count(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline count (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.Count(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `DefaultIfEmpty(source, defaultValue)`
    let inline defaultIfEmpty defaultValue source = System.Linq.Enumerable.DefaultIfEmpty(source, defaultValue)

    /// Calls `Distinct(source, comparer)`
    let inline distinct comparer source = System.Linq.Enumerable.Distinct(source, comparer)

    /// Calls `Except(first, second, comparer)`
    let inline except second comparer first = System.Linq.Enumerable.Except(first, second, comparer)

    /// Calls `First(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline first (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.First(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline firstOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)`
    let inline groupBy (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) (resultSelector:'TKey->System.Collections.Generic.IEnumerable<'TElement>->'TResult) comparer source = System.Linq.Enumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)

    /// Calls `GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector), comparer)`
    let inline groupJoin (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult) comparer outer inner = System.Linq.Enumerable.GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector), comparer)

    /// Calls `Intersect(first, second, comparer)`
    let inline intersect comparer first second = System.Linq.Enumerable.Intersect(first, second, comparer)

    /// Calls `Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector), comparer)`
    let inline join (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->'TInner->'TResult) comparer outer inner = System.Linq.Enumerable.Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector), comparer)

    /// Calls `Last(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline last (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.Last(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `LastOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline lastOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.LastOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `LongCount(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline longCount (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.LongCount(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `OrderBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline orderBy (keySelector:'TSource->'TKey) comparer source = System.Linq.Enumerable.OrderBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline orderByDescending (keySelector:'TSource->'TKey) comparer source = System.Linq.Enumerable.OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `SequenceEqual(first, second, comparer)`
    let inline sequenceEqual comparer first second = System.Linq.Enumerable.SequenceEqual(first, second, comparer)

    /// Calls `Single(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline single (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.Single(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline singleOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.Enumerable.SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline thenBy (keySelector:'TSource->'TKey) comparer source = System.Linq.Enumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
    let inline thenByDescending (keySelector:'TSource->'TKey) comparer source = System.Linq.Enumerable.ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

    /// Calls `ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`
    let inline toDictionary (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.Enumerable.ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)

    /// Calls `ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`
    let inline toLookup (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.Enumerable.ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)

    /// Calls `Union(first, second, comparer)`
    let inline union comparer first second = System.Linq.Enumerable.Union(first, second, comparer)
