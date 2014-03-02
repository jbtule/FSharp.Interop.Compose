// Generated with ComposableExtensions (0.9.1) http://jbtule.github.io/ComposableExtensions

namespace Composable.Linq
/// Corresponding `System.Linq.ParallelEnumerable` static methods as functions
module ParallelEnumerable =

    /// Calls `Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))`
    let inline aggregate (func:'TSource->'TSource->'TSource) source = System.Linq.ParallelEnumerable.Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))

    /// Calls `All(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline all (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.All(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `Any(source)`
    let inline any source = System.Linq.ParallelEnumerable.Any(source)

    /// Calls `AsEnumerable(source)`
    let inline asEnumerable source = System.Linq.ParallelEnumerable.AsEnumerable(source)

    /// Calls `AsOrdered(source)`
    let inline asOrdered (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.AsOrdered(source)

    /// Calls `AsSequential(source)`
    let inline asSequential source = System.Linq.ParallelEnumerable.AsSequential(source)

    /// Calls `AsUnordered(source)`
    let inline asUnordered source = System.Linq.ParallelEnumerable.AsUnordered(source)

    /// Calls `Cast<'TResult>(source)`
    let inline cast<'TResult> source = System.Linq.ParallelEnumerable.Cast<'TResult>(source)

    /// Calls `Concat(first, second)`
    let inline concat (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Concat(first, second)

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

    /// Calls `Except(first, second)`
    let inline except (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Except(first, second)

    /// Calls `First(source)`
    let inline first source = System.Linq.ParallelEnumerable.First(source)

    /// Calls `FirstOrDefault(source)`
    let inline firstOrDefault source = System.Linq.ParallelEnumerable.FirstOrDefault(source)

    /// Calls `ForAll(source, action)`
    let inline forAll action source = System.Linq.ParallelEnumerable.ForAll(source, action)

    /// Calls `GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))`
    let inline groupBy (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls `GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector))`
    let inline groupJoin (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Linq.ParallelQuery<'TInner>) = System.Linq.ParallelEnumerable.GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector))

    /// Calls `Intersect(first, second)`
    let inline intersect (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Intersect(first, second)

    /// Calls `Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector))`
    let inline join (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->'TInner->'TResult) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Linq.ParallelQuery<'TInner>) = System.Linq.ParallelEnumerable.Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector))

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

    /// Calls `Select(source, System.Func<'TSource, 'TResult>(selector))`
    let inline select (selector:'TSource->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Select(source, System.Func<'TSource, 'TResult>(selector))

    /// Calls `SelectMany(source, System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>(selector))`
    let inline selectMany (selector:'TSource->System.Collections.Generic.IEnumerable<'TResult>) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SelectMany(source, System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>(selector))

    /// Calls `SequenceEqual(first, second)`
    let inline sequenceEqual (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SequenceEqual(first, second)

    /// Calls `Single(source)`
    let inline single source = System.Linq.ParallelEnumerable.Single(source)

    /// Calls `SingleOrDefault(source)`
    let inline singleOrDefault source = System.Linq.ParallelEnumerable.SingleOrDefault(source)

    /// Calls `Skip(source, count)`
    let inline skip count source = System.Linq.ParallelEnumerable.Skip(source, count)

    /// Calls `SkipWhile(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline skipWhile (predicate:'TSource->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SkipWhile(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `Take(source, count)`
    let inline take count source = System.Linq.ParallelEnumerable.Take(source, count)

    /// Calls `TakeWhile(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline takeWhile (predicate:'TSource->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.TakeWhile(source, System.Func<'TSource, System.Boolean>(predicate))

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

    /// Calls `Union(first, second)`
    let inline union (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Union(first, second)

    /// Calls `Where(source, System.Func<'TSource, System.Boolean>(predicate))`
    let inline where (predicate:'TSource->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Where(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls `WithCancellation(source, cancellationToken)`
    let inline withCancellation cancellationToken source = System.Linq.ParallelEnumerable.WithCancellation(source, cancellationToken)

    /// Calls `WithDegreeOfParallelism(source, degreeOfParallelism)`
    let inline withDegreeOfParallelism degreeOfParallelism source = System.Linq.ParallelEnumerable.WithDegreeOfParallelism(source, degreeOfParallelism)

    /// Calls `WithExecutionMode(source, executionMode)`
    let inline withExecutionMode executionMode source = System.Linq.ParallelEnumerable.WithExecutionMode(source, executionMode)

    /// Calls `WithMergeOptions(source, mergeOptions)`
    let inline withMergeOptions mergeOptions source = System.Linq.ParallelEnumerable.WithMergeOptions(source, mergeOptions)

    /// Calls `Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))`
    let inline zip (resultSelector:'TFirst->'TSecond->'TResult) (first:System.Linq.ParallelQuery<'TFirst>) (second:System.Linq.ParallelQuery<'TSecond>) = System.Linq.ParallelEnumerable.Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))

    /// Longer parameter versions of `System.Linq.ParallelEnumerable` methods
    module Full =

        /// Calls `Aggregate(source, System.Func<'TAccumulate>(seedFactory), System.Func<'TAccumulate, 'TSource, 'TAccumulate>(updateAccumulatorFunc), System.Func<'TAccumulate, 'TAccumulate, 'TAccumulate>(combineAccumulatorsFunc), System.Func<'TAccumulate, 'TResult>(resultSelector))`
        let inline aggregate (seedFactory:unit->'TAccumulate) (updateAccumulatorFunc:'TAccumulate->'TSource->'TAccumulate) (combineAccumulatorsFunc:'TAccumulate->'TAccumulate->'TAccumulate) (resultSelector:'TAccumulate->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Aggregate(source, System.Func<'TAccumulate>(seedFactory), System.Func<'TAccumulate, 'TSource, 'TAccumulate>(updateAccumulatorFunc), System.Func<'TAccumulate, 'TAccumulate, 'TAccumulate>(combineAccumulatorsFunc), System.Func<'TAccumulate, 'TResult>(resultSelector))

        /// Calls `Any(source, System.Func<'TSource, System.Boolean>(predicate))`
        let inline any (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Any(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls `AsOrdered(source)`
        let inline asOrdered (source:System.Linq.ParallelQuery) = System.Linq.ParallelEnumerable.AsOrdered(source)

        /// Calls `Concat(first, second)`
        let inline concat (second:System.Collections.Generic.IEnumerable<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Concat(first, second)

        /// Calls `Contains(source, value, comparer)`
        let inline contains value comparer source = System.Linq.ParallelEnumerable.Contains(source, value, comparer)

        /// Calls `Count(source, System.Func<'TSource, System.Boolean>(predicate))`
        let inline count (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Count(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls `DefaultIfEmpty(source, defaultValue)`
        let inline defaultIfEmpty defaultValue source = System.Linq.ParallelEnumerable.DefaultIfEmpty(source, defaultValue)

        /// Calls `Distinct(source, comparer)`
        let inline distinct comparer source = System.Linq.ParallelEnumerable.Distinct(source, comparer)

        /// Calls `Except(first, second, comparer)`
        let inline except (second:System.Collections.Generic.IEnumerable<'TSource>) (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Except(first, second, comparer)

        /// Calls `First(source, System.Func<'TSource, System.Boolean>(predicate))`
        let inline first (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.First(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls `FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
        let inline firstOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls `GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)`
        let inline groupBy (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) (resultSelector:'TKey->System.Collections.Generic.IEnumerable<'TElement>->'TResult) comparer source = System.Linq.ParallelEnumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)

        /// Calls `GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector), comparer)`
        let inline groupJoin (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult) (comparer:System.Collections.Generic.IEqualityComparer<'TKey>) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Collections.Generic.IEnumerable<'TInner>) = System.Linq.ParallelEnumerable.GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector), comparer)

        /// Calls `Intersect(first, second, comparer)`
        let inline intersect (second:System.Collections.Generic.IEnumerable<'TSource>) (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Intersect(first, second, comparer)

        /// Calls `Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector), comparer)`
        let inline join (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->'TInner->'TResult) (comparer:System.Collections.Generic.IEqualityComparer<'TKey>) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Collections.Generic.IEnumerable<'TInner>) = System.Linq.ParallelEnumerable.Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector), comparer)

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

        /// Calls `Select(source, System.Func<'TSource, System.Int32, 'TResult>(selector))`
        let inline select (selector:'TSource->System.Int32->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Select(source, System.Func<'TSource, System.Int32, 'TResult>(selector))

        /// Calls `SelectMany(source, System.Func<'TSource, System.Int32, System.Collections.Generic.IEnumerable<'TCollection>>(collectionSelector), System.Func<'TSource, 'TCollection, 'TResult>(resultSelector))`
        let inline selectMany (collectionSelector:'TSource->System.Int32->System.Collections.Generic.IEnumerable<'TCollection>) (resultSelector:'TSource->'TCollection->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SelectMany(source, System.Func<'TSource, System.Int32, System.Collections.Generic.IEnumerable<'TCollection>>(collectionSelector), System.Func<'TSource, 'TCollection, 'TResult>(resultSelector))

        /// Calls `SequenceEqual(first, second, comparer)`
        let inline sequenceEqual (second:System.Collections.Generic.IEnumerable<'TSource>) (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SequenceEqual(first, second, comparer)

        /// Calls `Single(source, System.Func<'TSource, System.Boolean>(predicate))`
        let inline single (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Single(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls `SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`
        let inline singleOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls `SkipWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))`
        let inline skipWhile (predicate:'TSource->System.Int32->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SkipWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))

        /// Calls `TakeWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))`
        let inline takeWhile (predicate:'TSource->System.Int32->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.TakeWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))

        /// Calls `ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
        let inline thenBy (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

        /// Calls `ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`
        let inline thenByDescending (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

        /// Calls `ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`
        let inline toDictionary (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.ParallelEnumerable.ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)

        /// Calls `ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`
        let inline toLookup (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.ParallelEnumerable.ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)

        /// Calls `Union(first, second, comparer)`
        let inline union (second:System.Collections.Generic.IEnumerable<'TSource>) (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Union(first, second, comparer)

        /// Calls `Where(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))`
        let inline where (predicate:'TSource->System.Int32->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Where(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))

        /// Calls `Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))`
        let inline zip (second:System.Collections.Generic.IEnumerable<'TSecond>) (resultSelector:'TFirst->'TSecond->'TResult) (first:System.Linq.ParallelQuery<'TFirst>) = System.Linq.ParallelEnumerable.Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))
