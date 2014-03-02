// Generated with ComposableExtensions (0.9.1) http://jbtule.github.io/ComposableExtensions

#load "../../helpers/Quotations.fsx"

namespace Composable.Linq
/// Corresponding `System.Linq.Queryable` static methods as functions
module Queryable =

    /// Calls `Aggregate(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TSource, 'TSource>>(func))`
    let inline aggregate (func:Quotations.Expr<'TSource->'TSource->'TSource>) source = System.Linq.Queryable.Aggregate(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TSource, 'TSource>>(func))

    /// Calls `All(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
    let inline all (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.All(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls `Any(source)`
    let inline any source = System.Linq.Queryable.Any(source)

    /// Calls `AsQueryable(source)`
    let inline asQueryable (source:System.Collections.Generic.IEnumerable<'TElement>) = System.Linq.Queryable.AsQueryable(source)

    /// Calls `Cast<'TResult>(source)`
    let inline cast<'TResult> source = System.Linq.Queryable.Cast<'TResult>(source)

    /// Calls `Concat(source1, source2)`
    let inline concat source1 source2 = System.Linq.Queryable.Concat(source1, source2)

    /// Calls `Contains(source, item)`
    let inline contains item source = System.Linq.Queryable.Contains(source, item)

    /// Calls `Count(source)`
    let inline count source = System.Linq.Queryable.Count(source)

    /// Calls `DefaultIfEmpty(source)`
    let inline defaultIfEmpty source = System.Linq.Queryable.DefaultIfEmpty(source)

    /// Calls `Distinct(source)`
    let inline distinct source = System.Linq.Queryable.Distinct(source)

    /// Calls `ElementAt(source, index)`
    let inline elementAt index source = System.Linq.Queryable.ElementAt(source, index)

    /// Calls `ElementAtOrDefault(source, index)`
    let inline elementAtOrDefault index source = System.Linq.Queryable.ElementAtOrDefault(source, index)

    /// Calls `Except(source1, source2)`
    let inline except source2 source1 = System.Linq.Queryable.Except(source1, source2)

    /// Calls `First(source)`
    let inline first source = System.Linq.Queryable.First(source)

    /// Calls `FirstOrDefault(source)`
    let inline firstOrDefault source = System.Linq.Queryable.FirstOrDefault(source)

    /// Calls `GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`
    let inline groupBy (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls `GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector))`
    let inline groupJoin (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult>) outer inner = System.Linq.Queryable.GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector))

    /// Calls `Intersect(source1, source2)`
    let inline intersect source1 source2 = System.Linq.Queryable.Intersect(source1, source2)

    /// Calls `Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector))`
    let inline join (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->'TInner->'TResult>) outer inner = System.Linq.Queryable.Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector))

    /// Calls `Last(source)`
    let inline last source = System.Linq.Queryable.Last(source)

    /// Calls `LastOrDefault(source)`
    let inline lastOrDefault source = System.Linq.Queryable.LastOrDefault(source)

    /// Calls `LongCount(source)`
    let inline longCount source = System.Linq.Queryable.LongCount(source)

    /// Calls `Max(source)`
    let inline max source = System.Linq.Queryable.Max(source)

    /// Calls `Min(source)`
    let inline min source = System.Linq.Queryable.Min(source)

    /// Calls `OfType<'TResult>(source)`
    let inline ofType<'TResult> source = System.Linq.Queryable.OfType<'TResult>(source)

    /// Calls `OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`
    let inline orderBy (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls `OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`
    let inline orderByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls `Reverse(source)`
    let inline reverse source = System.Linq.Queryable.Reverse(source)

    /// Calls `Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))`
    let inline select (selector:Quotations.Expr<'TSource->'TResult>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))

    /// Calls `SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>>(selector))`
    let inline selectMany (selector:Quotations.Expr<'TSource->System.Collections.Generic.IEnumerable<'TResult>>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>>(selector))

    /// Calls `SequenceEqual(source1, source2)`
    let inline sequenceEqual source1 source2 = System.Linq.Queryable.SequenceEqual(source1, source2)

    /// Calls `Single(source)`
    let inline single source = System.Linq.Queryable.Single(source)

    /// Calls `SingleOrDefault(source)`
    let inline singleOrDefault source = System.Linq.Queryable.SingleOrDefault(source)

    /// Calls `Skip(source, count)`
    let inline skip count source = System.Linq.Queryable.Skip(source, count)

    /// Calls `SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
    let inline skipWhile (predicate:Quotations.Expr<'TSource->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls `Take(source, count)`
    let inline take count source = System.Linq.Queryable.Take(source, count)

    /// Calls `TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
    let inline takeWhile (predicate:Quotations.Expr<'TSource->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls `ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`
    let inline thenBy (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls `ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`
    let inline thenByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls `Union(source1, source2)`
    let inline union source1 source2 = System.Linq.Queryable.Union(source1, source2)

    /// Calls `Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
    let inline where (predicate:Quotations.Expr<'TSource->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls `Zip(source1, source2, ComposableExtensions.Quotations.toExpression<System.Func<'TFirst, 'TSecond, 'TResult>>(resultSelector))`
    let inline zip (resultSelector:Quotations.Expr<'TFirst->'TSecond->'TResult>) source1 source2 = System.Linq.Queryable.Zip(source1, source2, ComposableExtensions.Quotations.toExpression<System.Func<'TFirst, 'TSecond, 'TResult>>(resultSelector))

    /// Longer parameter versions of `System.Linq.Queryable` methods
    module Full =

        /// Calls `Aggregate(source, seed, ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TSource, 'TAccumulate>>(func), ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TResult>>(selector))`
        let inline aggregate seed (func:Quotations.Expr<'TAccumulate->'TSource->'TAccumulate>) (selector:Quotations.Expr<'TAccumulate->'TResult>) source = System.Linq.Queryable.Aggregate(source, seed, ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TSource, 'TAccumulate>>(func), ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TResult>>(selector))

        /// Calls `Any(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline any (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Any(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `AsQueryable(source)`
        let inline asQueryable (source:System.Collections.IEnumerable) = System.Linq.Queryable.AsQueryable(source)

        /// Calls `Contains(source, item, comparer)`
        let inline contains item comparer source = System.Linq.Queryable.Contains(source, item, comparer)

        /// Calls `Count(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline count (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Count(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `DefaultIfEmpty(source, defaultValue)`
        let inline defaultIfEmpty defaultValue source = System.Linq.Queryable.DefaultIfEmpty(source, defaultValue)

        /// Calls `Distinct(source, comparer)`
        let inline distinct comparer source = System.Linq.Queryable.Distinct(source, comparer)

        /// Calls `Except(source1, source2, comparer)`
        let inline except source2 comparer source1 = System.Linq.Queryable.Except(source1, source2, comparer)

        /// Calls `First(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline first (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.First(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `FirstOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline firstOrDefault (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.FirstOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TElement>>(elementSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>>(resultSelector), comparer)`
        let inline groupBy (keySelector:Quotations.Expr<'TSource->'TKey>) (elementSelector:Quotations.Expr<'TSource->'TElement>) (resultSelector:Quotations.Expr<'TKey->System.Collections.Generic.IEnumerable<'TElement>->'TResult>) comparer source = System.Linq.Queryable.GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TElement>>(elementSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>>(resultSelector), comparer)

        /// Calls `GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector), comparer)`
        let inline groupJoin (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult>) comparer outer inner = System.Linq.Queryable.GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector), comparer)

        /// Calls `Intersect(source1, source2, comparer)`
        let inline intersect comparer source1 source2 = System.Linq.Queryable.Intersect(source1, source2, comparer)

        /// Calls `Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector), comparer)`
        let inline join (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->'TInner->'TResult>) comparer outer inner = System.Linq.Queryable.Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector), comparer)

        /// Calls `Last(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline last (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Last(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `LastOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline lastOrDefault (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.LastOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `LongCount(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline longCount (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.LongCount(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `Max(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))`
        let inline max (selector:Quotations.Expr<'TSource->'TResult>) source = System.Linq.Queryable.Max(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))

        /// Calls `Min(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))`
        let inline min (selector:Quotations.Expr<'TSource->'TResult>) source = System.Linq.Queryable.Min(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))

        /// Calls `OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`
        let inline orderBy (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls `OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`
        let inline orderByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls `Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, 'TResult>>(selector))`
        let inline select (selector:Quotations.Expr<'TSource->System.Int32->'TResult>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, 'TResult>>(selector))

        /// Calls `SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Collections.Generic.IEnumerable<'TCollection>>>(collectionSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TCollection, 'TResult>>(resultSelector))`
        let inline selectMany (collectionSelector:Quotations.Expr<'TSource->System.Collections.Generic.IEnumerable<'TCollection>>) (resultSelector:Quotations.Expr<'TSource->'TCollection->'TResult>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Collections.Generic.IEnumerable<'TCollection>>>(collectionSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TCollection, 'TResult>>(resultSelector))

        /// Calls `SequenceEqual(source1, source2, comparer)`
        let inline sequenceEqual comparer source1 source2 = System.Linq.Queryable.SequenceEqual(source1, source2, comparer)

        /// Calls `Single(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline single (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Single(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `SingleOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`
        let inline singleOrDefault (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.SingleOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls `SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))`
        let inline skipWhile (predicate:Quotations.Expr<'TSource->System.Int32->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))

        /// Calls `TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))`
        let inline takeWhile (predicate:Quotations.Expr<'TSource->System.Int32->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))

        /// Calls `ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`
        let inline thenBy (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls `ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`
        let inline thenByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls `Union(source1, source2, comparer)`
        let inline union comparer source1 source2 = System.Linq.Queryable.Union(source1, source2, comparer)

        /// Calls `Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))`
        let inline where (predicate:Quotations.Expr<'TSource->System.Int32->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))
