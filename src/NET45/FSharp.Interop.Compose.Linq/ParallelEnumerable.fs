// Generated with FSharp.Interop.Compose (1.14.0) http://jbtule.github.io/FSharp.Interop.Compose

namespace FSharp.Interop.Compose.Linq
/// Corresponding static methods as functions for [`System.Linq.ParallelEnumerable`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable)
module ParallelEnumerable =

    /// Calls [`Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.aggregate)
    let inline aggregate (func:'TSource->'TSource->'TSource) source = System.Linq.ParallelEnumerable.Aggregate(source, System.Func<'TSource, 'TSource, 'TSource>(func))

    /// Calls [`All(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.all)
    let inline all (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.All(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls [`Any(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.any)
    let inline any source = System.Linq.ParallelEnumerable.Any(source)

    /// Calls [`AsEnumerable(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.asenumerable)
    let inline asEnumerable source = System.Linq.ParallelEnumerable.AsEnumerable(source)

    /// Calls [`AsOrdered(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.asordered)
    let inline asOrdered (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.AsOrdered(source)

    /// Calls [`AsSequential(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.assequential)
    let inline asSequential source = System.Linq.ParallelEnumerable.AsSequential(source)

    /// Calls [`AsUnordered(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.asunordered)
    let inline asUnordered source = System.Linq.ParallelEnumerable.AsUnordered(source)

    /// Calls [`Cast<'TResult>(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.cast)
    let inline cast<'TResult> source = System.Linq.ParallelEnumerable.Cast<'TResult>(source)

    /// Calls [`Concat(first, second)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.concat)
    let inline concat (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Concat(first, second)

    /// Calls [`Contains(source, value)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.contains)
    let inline contains value source = System.Linq.ParallelEnumerable.Contains(source, value)

    /// Calls [`Count(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.count)
    let inline count source = System.Linq.ParallelEnumerable.Count(source)

    /// Calls [`DefaultIfEmpty(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.defaultifempty)
    let inline defaultIfEmpty source = System.Linq.ParallelEnumerable.DefaultIfEmpty(source)

    /// Calls [`Distinct(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.distinct)
    let inline distinct source = System.Linq.ParallelEnumerable.Distinct(source)

    /// Calls [`ElementAt(source, index)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.elementat)
    let inline elementAt index source = System.Linq.ParallelEnumerable.ElementAt(source, index)

    /// Calls [`ElementAtOrDefault(source, index)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.elementatordefault)
    let inline elementAtOrDefault index source = System.Linq.ParallelEnumerable.ElementAtOrDefault(source, index)

    /// Calls [`Except(first, second)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.except)
    let inline except (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Except(first, second)

    /// Calls [`First(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.first)
    let inline first source = System.Linq.ParallelEnumerable.First(source)

    /// Calls [`FirstOrDefault(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.firstordefault)
    let inline firstOrDefault source = System.Linq.ParallelEnumerable.FirstOrDefault(source)

    /// Calls [`ForAll(source, System.Action<'TSource>(action))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.forall)
    let inline forAll (action:'TSource->Microsoft.FSharp.Core.unit) source = System.Linq.ParallelEnumerable.ForAll(source, System.Action<'TSource>(action))

    /// Calls [`GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.groupby)
    let inline groupBy (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls [`GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.groupjoin)
    let inline groupJoin (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Linq.ParallelQuery<'TInner>) = System.Linq.ParallelEnumerable.GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector))

    /// Calls [`Intersect(first, second)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.intersect)
    let inline intersect (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Intersect(first, second)

    /// Calls [`Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.join)
    let inline join (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->'TInner->'TResult) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Linq.ParallelQuery<'TInner>) = System.Linq.ParallelEnumerable.Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector))

    /// Calls [`Last(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.last)
    let inline last source = System.Linq.ParallelEnumerable.Last(source)

    /// Calls [`LastOrDefault(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.lastordefault)
    let inline lastOrDefault source = System.Linq.ParallelEnumerable.LastOrDefault(source)

    /// Calls [`LongCount(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.longcount)
    let inline longCount source = System.Linq.ParallelEnumerable.LongCount(source)

    /// Calls [`OfType<'TResult>(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.oftype)
    let inline ofType<'TResult> source = System.Linq.ParallelEnumerable.OfType<'TResult>(source)

    /// Calls [`OrderBy(source, System.Func<'TSource, 'TKey>(keySelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.orderby)
    let inline orderBy (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.OrderBy(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls [`OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.orderbydescending)
    let inline orderByDescending (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls [`Reverse(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.reverse)
    let inline reverse source = System.Linq.ParallelEnumerable.Reverse(source)

    /// Calls [`Select(source, System.Func<'TSource, 'TResult>(selector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.select)
    let inline select (selector:'TSource->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Select(source, System.Func<'TSource, 'TResult>(selector))

    /// Calls [`SelectMany(source, System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>(selector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.selectmany)
    let inline selectMany (selector:'TSource->System.Collections.Generic.IEnumerable<'TResult>) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SelectMany(source, System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>(selector))

    /// Calls [`SequenceEqual(first, second)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.sequenceequal)
    let inline sequenceEqual (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SequenceEqual(first, second)

    /// Calls [`Single(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.single)
    let inline single source = System.Linq.ParallelEnumerable.Single(source)

    /// Calls [`SingleOrDefault(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.singleordefault)
    let inline singleOrDefault source = System.Linq.ParallelEnumerable.SingleOrDefault(source)

    /// Calls [`Skip(source, count)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.skip)
    let inline skip count source = System.Linq.ParallelEnumerable.Skip(source, count)

    /// Calls [`SkipWhile(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.skipwhile)
    let inline skipWhile (predicate:'TSource->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SkipWhile(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls [`Take(source, count)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.take)
    let inline take count source = System.Linq.ParallelEnumerable.Take(source, count)

    /// Calls [`TakeWhile(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.takewhile)
    let inline takeWhile (predicate:'TSource->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.TakeWhile(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls [`ThenBy(source, System.Func<'TSource, 'TKey>(keySelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.thenby)
    let inline thenBy (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls [`ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.thenbydescending)
    let inline thenByDescending (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls [`ToArray(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.toarray)
    let inline toArray source = System.Linq.ParallelEnumerable.ToArray(source)

    /// Calls [`ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.todictionary)
    let inline toDictionary (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls [`ToList(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.tolist)
    let inline toList source = System.Linq.ParallelEnumerable.ToList(source)

    /// Calls [`ToLookup(source, System.Func<'TSource, 'TKey>(keySelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.tolookup)
    let inline toLookup (keySelector:'TSource->'TKey) source = System.Linq.ParallelEnumerable.ToLookup(source, System.Func<'TSource, 'TKey>(keySelector))

    /// Calls [`Union(first, second)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.union)
    let inline union (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Union(first, second)

    /// Calls [`Where(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.where)
    let inline where (predicate:'TSource->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Where(source, System.Func<'TSource, System.Boolean>(predicate))

    /// Calls [`WithCancellation(source, cancellationToken)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.withcancellation)
    let inline withCancellation cancellationToken source = System.Linq.ParallelEnumerable.WithCancellation(source, cancellationToken)

    /// Calls [`WithDegreeOfParallelism(source, degreeOfParallelism)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.withdegreeofparallelism)
    let inline withDegreeOfParallelism degreeOfParallelism source = System.Linq.ParallelEnumerable.WithDegreeOfParallelism(source, degreeOfParallelism)

    /// Calls [`WithExecutionMode(source, executionMode)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.withexecutionmode)
    let inline withExecutionMode executionMode source = System.Linq.ParallelEnumerable.WithExecutionMode(source, executionMode)

    /// Calls [`WithMergeOptions(source, mergeOptions)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.withmergeoptions)
    let inline withMergeOptions mergeOptions source = System.Linq.ParallelEnumerable.WithMergeOptions(source, mergeOptions)

    /// Calls [`Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.zip)
    let inline zip (resultSelector:'TFirst->'TSecond->'TResult) (first:System.Linq.ParallelQuery<'TFirst>) (second:System.Linq.ParallelQuery<'TSecond>) = System.Linq.ParallelEnumerable.Zip(first, second, System.Func<'TFirst, 'TSecond, 'TResult>(resultSelector))

    /// Longer parameter versions of `System.Linq.ParallelEnumerable` methods
    module Full =

        /// Calls [`Aggregate(source, System.Func<'TAccumulate>(seedFactory), System.Func<'TAccumulate, 'TSource, 'TAccumulate>(updateAccumulatorFunc), System.Func<'TAccumulate, 'TAccumulate, 'TAccumulate>(combineAccumulatorsFunc), System.Func<'TAccumulate, 'TResult>(resultSelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.aggregate)
        let inline aggregate (seedFactory:unit->'TAccumulate) (updateAccumulatorFunc:'TAccumulate->'TSource->'TAccumulate) (combineAccumulatorsFunc:'TAccumulate->'TAccumulate->'TAccumulate) (resultSelector:'TAccumulate->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Aggregate(source, System.Func<'TAccumulate>(seedFactory), System.Func<'TAccumulate, 'TSource, 'TAccumulate>(updateAccumulatorFunc), System.Func<'TAccumulate, 'TAccumulate, 'TAccumulate>(combineAccumulatorsFunc), System.Func<'TAccumulate, 'TResult>(resultSelector))

        /// Calls [`Any(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.any)
        let inline any (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Any(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`AsOrdered(source)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.asordered)
        let inline asOrdered (source:System.Linq.ParallelQuery) = System.Linq.ParallelEnumerable.AsOrdered(source)

        /// Calls [`Contains(source, value, comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.contains)
        let inline contains value comparer source = System.Linq.ParallelEnumerable.Contains(source, value, comparer)

        /// Calls [`Count(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.count)
        let inline count (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Count(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`DefaultIfEmpty(source, defaultValue)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.defaultifempty)
        let inline defaultIfEmpty defaultValue source = System.Linq.ParallelEnumerable.DefaultIfEmpty(source, defaultValue)

        /// Calls [`Distinct(source, comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.distinct)
        let inline distinct comparer source = System.Linq.ParallelEnumerable.Distinct(source, comparer)

        /// Calls [`Except(first, second, comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.except)
        let inline except (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Except(first, second, comparer)

        /// Calls [`First(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.first)
        let inline first (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.First(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.firstordefault)
        let inline firstOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.FirstOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.groupby)
        let inline groupBy (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) (resultSelector:'TKey->System.Collections.Generic.IEnumerable<'TElement>->'TResult) comparer source = System.Linq.ParallelEnumerable.GroupBy(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>(resultSelector), comparer)

        /// Calls [`GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.groupjoin)
        let inline groupJoin (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult) (comparer:System.Collections.Generic.IEqualityComparer<'TKey>) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Linq.ParallelQuery<'TInner>) = System.Linq.ParallelEnumerable.GroupJoin(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>(resultSelector), comparer)

        /// Calls [`Intersect(first, second, comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.intersect)
        let inline intersect (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Intersect(first, second, comparer)

        /// Calls [`Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.join)
        let inline join (outerKeySelector:'TOuter->'TKey) (innerKeySelector:'TInner->'TKey) (resultSelector:'TOuter->'TInner->'TResult) (comparer:System.Collections.Generic.IEqualityComparer<'TKey>) (outer:System.Linq.ParallelQuery<'TOuter>) (inner:System.Linq.ParallelQuery<'TInner>) = System.Linq.ParallelEnumerable.Join(outer, inner, System.Func<'TOuter, 'TKey>(outerKeySelector), System.Func<'TInner, 'TKey>(innerKeySelector), System.Func<'TOuter, 'TInner, 'TResult>(resultSelector), comparer)

        /// Calls [`Last(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.last)
        let inline last (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Last(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`LastOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.lastordefault)
        let inline lastOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.LastOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`LongCount(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.longcount)
        let inline longCount (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.LongCount(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`OrderBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.orderby)
        let inline orderBy (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.OrderBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

        /// Calls [`OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.orderbydescending)
        let inline orderByDescending (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

        /// Calls [`Select(source, System.Func<'TSource, System.Int32, 'TResult>(selector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.select)
        let inline select (selector:'TSource->System.Int32->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Select(source, System.Func<'TSource, System.Int32, 'TResult>(selector))

        /// Calls [`SelectMany(source, System.Func<'TSource, System.Int32, System.Collections.Generic.IEnumerable<'TCollection>>(collectionSelector), System.Func<'TSource, 'TCollection, 'TResult>(resultSelector))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.selectmany)
        let inline selectMany (collectionSelector:'TSource->System.Int32->System.Collections.Generic.IEnumerable<'TCollection>) (resultSelector:'TSource->'TCollection->'TResult) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SelectMany(source, System.Func<'TSource, System.Int32, System.Collections.Generic.IEnumerable<'TCollection>>(collectionSelector), System.Func<'TSource, 'TCollection, 'TResult>(resultSelector))

        /// Calls [`SequenceEqual(first, second, comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.sequenceequal)
        let inline sequenceEqual (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SequenceEqual(first, second, comparer)

        /// Calls [`Single(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.single)
        let inline single (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.Single(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.singleordefault)
        let inline singleOrDefault (predicate:'TSource->System.Boolean) source = System.Linq.ParallelEnumerable.SingleOrDefault(source, System.Func<'TSource, System.Boolean>(predicate))

        /// Calls [`SkipWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.skipwhile)
        let inline skipWhile (predicate:'TSource->System.Int32->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.SkipWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))

        /// Calls [`TakeWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.takewhile)
        let inline takeWhile (predicate:'TSource->System.Int32->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.TakeWhile(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))

        /// Calls [`ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.thenby)
        let inline thenBy (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

        /// Calls [`ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.thenbydescending)
        let inline thenByDescending (keySelector:'TSource->'TKey) comparer source = System.Linq.ParallelEnumerable.ThenByDescending(source, System.Func<'TSource, 'TKey>(keySelector), comparer)

        /// Calls [`ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.todictionary)
        let inline toDictionary (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.ParallelEnumerable.ToDictionary(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)

        /// Calls [`ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.tolookup)
        let inline toLookup (keySelector:'TSource->'TKey) (elementSelector:'TSource->'TElement) comparer source = System.Linq.ParallelEnumerable.ToLookup(source, System.Func<'TSource, 'TKey>(keySelector), System.Func<'TSource, 'TElement>(elementSelector), comparer)

        /// Calls [`Union(first, second, comparer)`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.union)
        let inline union (comparer:System.Collections.Generic.IEqualityComparer<'TSource>) (first:System.Linq.ParallelQuery<'TSource>) (second:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Union(first, second, comparer)

        /// Calls [`Where(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.where)
        let inline where (predicate:'TSource->System.Int32->System.Boolean) (source:System.Linq.ParallelQuery<'TSource>) = System.Linq.ParallelEnumerable.Where(source, System.Func<'TSource, System.Int32, System.Boolean>(predicate))
