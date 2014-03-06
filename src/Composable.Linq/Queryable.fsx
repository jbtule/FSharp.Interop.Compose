// Generated with ComposableExtensions (0.10.3) http://jbtule.github.io/ComposableExtensions

#load "../../helpers/Quotations.fsx"

namespace Composable.Linq
/// Corresponding static methods as functions for [`System.Linq.Queryable`](http://msdn.microsoft.com/en-us/library/system.linq.queryable)
module Queryable =

    /// Calls [`Aggregate(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TSource, 'TSource>>(func))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.aggregate)
    let inline aggregate (func:Quotations.Expr<'TSource->'TSource->'TSource>) source = System.Linq.Queryable.Aggregate(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TSource, 'TSource>>(func))

    /// Calls [`All(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.all)
    let inline all (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.All(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls [`Any(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.any)
    let inline any source = System.Linq.Queryable.Any(source)

    /// Calls [`AsQueryable(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.asqueryable)
    let inline asQueryable (source:System.Collections.Generic.IEnumerable<'TElement>) = System.Linq.Queryable.AsQueryable(source)

    /// Calls [`Cast<'TResult>(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.cast)
    let inline cast<'TResult> source = System.Linq.Queryable.Cast<'TResult>(source)

    /// Calls [`Concat(source1, source2)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.concat)
    let inline concat source1 source2 = System.Linq.Queryable.Concat(source1, source2)

    /// Calls [`Contains(source, item)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.contains)
    let inline contains item source = System.Linq.Queryable.Contains(source, item)

    /// Calls [`Count(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.count)
    let inline count source = System.Linq.Queryable.Count(source)

    /// Calls [`DefaultIfEmpty(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.defaultifempty)
    let inline defaultIfEmpty source = System.Linq.Queryable.DefaultIfEmpty(source)

    /// Calls [`Distinct(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.distinct)
    let inline distinct source = System.Linq.Queryable.Distinct(source)

    /// Calls [`ElementAt(source, index)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.elementat)
    let inline elementAt index source = System.Linq.Queryable.ElementAt(source, index)

    /// Calls [`ElementAtOrDefault(source, index)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.elementatordefault)
    let inline elementAtOrDefault index source = System.Linq.Queryable.ElementAtOrDefault(source, index)

    /// Calls [`Except(source1, source2)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.except)
    let inline except source2 source1 = System.Linq.Queryable.Except(source1, source2)

    /// Calls [`First(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.first)
    let inline first source = System.Linq.Queryable.First(source)

    /// Calls [`FirstOrDefault(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.firstordefault)
    let inline firstOrDefault source = System.Linq.Queryable.FirstOrDefault(source)

    /// Calls [`GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.groupby)
    let inline groupBy (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls [`GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.groupjoin)
    let inline groupJoin (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult>) outer inner = System.Linq.Queryable.GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector))

    /// Calls [`Intersect(source1, source2)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.intersect)
    let inline intersect source1 source2 = System.Linq.Queryable.Intersect(source1, source2)

    /// Calls [`Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.join)
    let inline join (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->'TInner->'TResult>) outer inner = System.Linq.Queryable.Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector))

    /// Calls [`Last(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.last)
    let inline last source = System.Linq.Queryable.Last(source)

    /// Calls [`LastOrDefault(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.lastordefault)
    let inline lastOrDefault source = System.Linq.Queryable.LastOrDefault(source)

    /// Calls [`LongCount(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.longcount)
    let inline longCount source = System.Linq.Queryable.LongCount(source)

    /// Calls [`Max(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.max)
    let inline max source = System.Linq.Queryable.Max(source)

    /// Calls [`Min(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.min)
    let inline min source = System.Linq.Queryable.Min(source)

    /// Calls [`OfType<'TResult>(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.oftype)
    let inline ofType<'TResult> source = System.Linq.Queryable.OfType<'TResult>(source)

    /// Calls [`OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.orderby)
    let inline orderBy (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls [`OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.orderbydescending)
    let inline orderByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls [`Reverse(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.reverse)
    let inline reverse source = System.Linq.Queryable.Reverse(source)

    /// Calls [`Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.select)
    let inline select (selector:Quotations.Expr<'TSource->'TResult>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))

    /// Calls [`SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>>(selector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.selectmany)
    let inline selectMany (selector:Quotations.Expr<'TSource->System.Collections.Generic.IEnumerable<'TResult>>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Collections.Generic.IEnumerable<'TResult>>>(selector))

    /// Calls [`SequenceEqual(source1, source2)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.sequenceequal)
    let inline sequenceEqual source1 source2 = System.Linq.Queryable.SequenceEqual(source1, source2)

    /// Calls [`Single(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.single)
    let inline single source = System.Linq.Queryable.Single(source)

    /// Calls [`SingleOrDefault(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.singleordefault)
    let inline singleOrDefault source = System.Linq.Queryable.SingleOrDefault(source)

    /// Calls [`Skip(source, count)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.skip)
    let inline skip count source = System.Linq.Queryable.Skip(source, count)

    /// Calls [`SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.skipwhile)
    let inline skipWhile (predicate:Quotations.Expr<'TSource->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls [`Take(source, count)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.take)
    let inline take count source = System.Linq.Queryable.Take(source, count)

    /// Calls [`TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.takewhile)
    let inline takeWhile (predicate:Quotations.Expr<'TSource->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls [`ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.thenby)
    let inline thenBy (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls [`ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.thenbydescending)
    let inline thenByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) source = System.Linq.Queryable.ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector))

    /// Calls [`Union(source1, source2)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.union)
    let inline union source1 source2 = System.Linq.Queryable.Union(source1, source2)

    /// Calls [`Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.where)
    let inline where (predicate:Quotations.Expr<'TSource->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

    /// Calls [`Zip(source1, source2, ComposableExtensions.Quotations.toExpression<System.Func<'TFirst, 'TSecond, 'TResult>>(resultSelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.zip)
    let inline zip (resultSelector:Quotations.Expr<'TFirst->'TSecond->'TResult>) source1 source2 = System.Linq.Queryable.Zip(source1, source2, ComposableExtensions.Quotations.toExpression<System.Func<'TFirst, 'TSecond, 'TResult>>(resultSelector))

    /// Longer parameter versions of `System.Linq.Queryable` methods
    module Full =

        /// Calls [`Aggregate(source, seed, ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TSource, 'TAccumulate>>(func), ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TResult>>(selector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.aggregate)
        let inline aggregate seed (func:Quotations.Expr<'TAccumulate->'TSource->'TAccumulate>) (selector:Quotations.Expr<'TAccumulate->'TResult>) source = System.Linq.Queryable.Aggregate(source, seed, ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TSource, 'TAccumulate>>(func), ComposableExtensions.Quotations.toExpression<System.Func<'TAccumulate, 'TResult>>(selector))

        /// Calls [`Any(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.any)
        let inline any (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Any(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`AsQueryable(source)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.asqueryable)
        let inline asQueryable (source:System.Collections.IEnumerable) = System.Linq.Queryable.AsQueryable(source)

        /// Calls [`Contains(source, item, comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.contains)
        let inline contains item comparer source = System.Linq.Queryable.Contains(source, item, comparer)

        /// Calls [`Count(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.count)
        let inline count (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Count(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`DefaultIfEmpty(source, defaultValue)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.defaultifempty)
        let inline defaultIfEmpty defaultValue source = System.Linq.Queryable.DefaultIfEmpty(source, defaultValue)

        /// Calls [`Distinct(source, comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.distinct)
        let inline distinct comparer source = System.Linq.Queryable.Distinct(source, comparer)

        /// Calls [`Except(source1, source2, comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.except)
        let inline except source2 comparer source1 = System.Linq.Queryable.Except(source1, source2, comparer)

        /// Calls [`First(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.first)
        let inline first (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.First(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`FirstOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.firstordefault)
        let inline firstOrDefault (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.FirstOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TElement>>(elementSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>>(resultSelector), comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.groupby)
        let inline groupBy (keySelector:Quotations.Expr<'TSource->'TKey>) (elementSelector:Quotations.Expr<'TSource->'TElement>) (resultSelector:Quotations.Expr<'TKey->System.Collections.Generic.IEnumerable<'TElement>->'TResult>) comparer source = System.Linq.Queryable.GroupBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TElement>>(elementSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TKey, System.Collections.Generic.IEnumerable<'TElement>, 'TResult>>(resultSelector), comparer)

        /// Calls [`GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector), comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.groupjoin)
        let inline groupJoin (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->System.Collections.Generic.IEnumerable<'TInner>->'TResult>) comparer outer inner = System.Linq.Queryable.GroupJoin(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, System.Collections.Generic.IEnumerable<'TInner>, 'TResult>>(resultSelector), comparer)

        /// Calls [`Intersect(source1, source2, comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.intersect)
        let inline intersect comparer source1 source2 = System.Linq.Queryable.Intersect(source1, source2, comparer)

        /// Calls [`Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector), comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.join)
        let inline join (outerKeySelector:Quotations.Expr<'TOuter->'TKey>) (innerKeySelector:Quotations.Expr<'TInner->'TKey>) (resultSelector:Quotations.Expr<'TOuter->'TInner->'TResult>) comparer outer inner = System.Linq.Queryable.Join(outer, inner, ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TKey>>(outerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TInner, 'TKey>>(innerKeySelector), ComposableExtensions.Quotations.toExpression<System.Func<'TOuter, 'TInner, 'TResult>>(resultSelector), comparer)

        /// Calls [`Last(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.last)
        let inline last (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Last(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`LastOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.lastordefault)
        let inline lastOrDefault (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.LastOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`LongCount(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.longcount)
        let inline longCount (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.LongCount(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`Max(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.max)
        let inline max (selector:Quotations.Expr<'TSource->'TResult>) source = System.Linq.Queryable.Max(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))

        /// Calls [`Min(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.min)
        let inline min (selector:Quotations.Expr<'TSource->'TResult>) source = System.Linq.Queryable.Min(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TResult>>(selector))

        /// Calls [`OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.orderby)
        let inline orderBy (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.OrderBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls [`OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.orderbydescending)
        let inline orderByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.OrderByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls [`Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, 'TResult>>(selector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.select)
        let inline select (selector:Quotations.Expr<'TSource->System.Int32->'TResult>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Select(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, 'TResult>>(selector))

        /// Calls [`SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Collections.Generic.IEnumerable<'TCollection>>>(collectionSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TCollection, 'TResult>>(resultSelector))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.selectmany)
        let inline selectMany (collectionSelector:Quotations.Expr<'TSource->System.Int32->System.Collections.Generic.IEnumerable<'TCollection>>) (resultSelector:Quotations.Expr<'TSource->'TCollection->'TResult>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SelectMany(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Collections.Generic.IEnumerable<'TCollection>>>(collectionSelector), ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TCollection, 'TResult>>(resultSelector))

        /// Calls [`SequenceEqual(source1, source2, comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.sequenceequal)
        let inline sequenceEqual comparer source1 source2 = System.Linq.Queryable.SequenceEqual(source1, source2, comparer)

        /// Calls [`Single(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.single)
        let inline single (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.Single(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`SingleOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.singleordefault)
        let inline singleOrDefault (predicate:Quotations.Expr<'TSource->System.Boolean>) source = System.Linq.Queryable.SingleOrDefault(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Boolean>>(predicate))

        /// Calls [`SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.skipwhile)
        let inline skipWhile (predicate:Quotations.Expr<'TSource->System.Int32->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.SkipWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))

        /// Calls [`TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.takewhile)
        let inline takeWhile (predicate:Quotations.Expr<'TSource->System.Int32->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.TakeWhile(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))

        /// Calls [`ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.thenby)
        let inline thenBy (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.ThenBy(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls [`ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.thenbydescending)
        let inline thenByDescending (keySelector:Quotations.Expr<'TSource->'TKey>) comparer source = System.Linq.Queryable.ThenByDescending(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, 'TKey>>(keySelector), comparer)

        /// Calls [`Union(source1, source2, comparer)`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.union)
        let inline union comparer source1 source2 = System.Linq.Queryable.Union(source1, source2, comparer)

        /// Calls [`Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))`](http://msdn.microsoft.com/en-us/library/system.linq.queryable.where)
        let inline where (predicate:Quotations.Expr<'TSource->System.Int32->System.Boolean>) (source:System.Linq.IQueryable<'TSource>) = System.Linq.Queryable.Where(source, ComposableExtensions.Quotations.toExpression<System.Func<'TSource, System.Int32, System.Boolean>>(predicate))
