// Generated with ComposableExtensions (0.5) https://github.com/jbtule/ComposableExtensions

module Composable.Linq.Queryable

let aggregate func source = System.Linq.Queryable.Aggregate(source,func)

let all predicate source = System.Linq.Queryable.All(source,predicate)

let any source = System.Linq.Queryable.Any(source)

let cast source = System.Linq.Queryable.Cast(source)

let concat source1 source2 = System.Linq.Queryable.Concat(source1,source2)

let contains item source = System.Linq.Queryable.Contains(source,item)

let count source = System.Linq.Queryable.Count(source)

let defaultIfEmpty source = System.Linq.Queryable.DefaultIfEmpty(source)

let distinct source = System.Linq.Queryable.Distinct(source)

let elementAt index source = System.Linq.Queryable.ElementAt(source,index)

let elementAtOrDefault index source = System.Linq.Queryable.ElementAtOrDefault(source,index)

let except source1 source2 = System.Linq.Queryable.Except(source1,source2)

let first source = System.Linq.Queryable.First(source)

let firstOrDefault source = System.Linq.Queryable.FirstOrDefault(source)

let groupBy keySelector source = System.Linq.Queryable.GroupBy(source,keySelector)

let groupJoin outerKeySelector innerKeySelector resultSelector outer inner = System.Linq.Queryable.GroupJoin(outer,inner,outerKeySelector,innerKeySelector,resultSelector)

let intersect source1 source2 = System.Linq.Queryable.Intersect(source1,source2)

let join outerKeySelector innerKeySelector resultSelector outer inner = System.Linq.Queryable.Join(outer,inner,outerKeySelector,innerKeySelector,resultSelector)

let last source = System.Linq.Queryable.Last(source)

let lastOrDefault source = System.Linq.Queryable.LastOrDefault(source)

let longCount source = System.Linq.Queryable.LongCount(source)

let max source = System.Linq.Queryable.Max(source)

let min source = System.Linq.Queryable.Min(source)

let ofType source = System.Linq.Queryable.OfType(source)

let orderBy keySelector source = System.Linq.Queryable.OrderBy(source,keySelector)

let orderByDescending keySelector source = System.Linq.Queryable.OrderByDescending(source,keySelector)

let reverse source = System.Linq.Queryable.Reverse(source)

let sequenceEqual source1 source2 = System.Linq.Queryable.SequenceEqual(source1,source2)

let single source = System.Linq.Queryable.Single(source)

let singleOrDefault source = System.Linq.Queryable.SingleOrDefault(source)

let skip count source = System.Linq.Queryable.Skip(source,count)

let take count source = System.Linq.Queryable.Take(source,count)

let thenBy keySelector source = System.Linq.Queryable.ThenBy(source,keySelector)

let thenByDescending keySelector source = System.Linq.Queryable.ThenByDescending(source,keySelector)

let union source1 source2 = System.Linq.Queryable.Union(source1,source2)

let zip resultSelector source1 source2 = System.Linq.Queryable.Zip(source1,source2,resultSelector)

module Full =

    let aggregate seed func selector source = System.Linq.Queryable.Aggregate(source,seed,func,selector)

    let any predicate source = System.Linq.Queryable.Any(source,predicate)

    let contains item comparer source = System.Linq.Queryable.Contains(source,item,comparer)

    let count predicate source = System.Linq.Queryable.Count(source,predicate)

    let defaultIfEmpty defaultValue source = System.Linq.Queryable.DefaultIfEmpty(source,defaultValue)

    let distinct comparer source = System.Linq.Queryable.Distinct(source,comparer)

    let except comparer source1 source2 = System.Linq.Queryable.Except(source1,source2,comparer)

    let first predicate source = System.Linq.Queryable.First(source,predicate)

    let firstOrDefault predicate source = System.Linq.Queryable.FirstOrDefault(source,predicate)

    let groupBy keySelector elementSelector resultSelector comparer source = System.Linq.Queryable.GroupBy(source,keySelector,elementSelector,resultSelector,comparer)

    let groupJoin outerKeySelector innerKeySelector resultSelector comparer outer inner = System.Linq.Queryable.GroupJoin(outer,inner,outerKeySelector,innerKeySelector,resultSelector,comparer)

    let intersect comparer source1 source2 = System.Linq.Queryable.Intersect(source1,source2,comparer)

    let join outerKeySelector innerKeySelector resultSelector comparer outer inner = System.Linq.Queryable.Join(outer,inner,outerKeySelector,innerKeySelector,resultSelector,comparer)

    let last predicate source = System.Linq.Queryable.Last(source,predicate)

    let lastOrDefault predicate source = System.Linq.Queryable.LastOrDefault(source,predicate)

    let longCount predicate source = System.Linq.Queryable.LongCount(source,predicate)

    let max selector source = System.Linq.Queryable.Max(source,selector)

    let min selector source = System.Linq.Queryable.Min(source,selector)

    let orderBy keySelector comparer source = System.Linq.Queryable.OrderBy(source,keySelector,comparer)

    let orderByDescending keySelector comparer source = System.Linq.Queryable.OrderByDescending(source,keySelector,comparer)

    let sequenceEqual comparer source1 source2 = System.Linq.Queryable.SequenceEqual(source1,source2,comparer)

    let single predicate source = System.Linq.Queryable.Single(source,predicate)

    let singleOrDefault predicate source = System.Linq.Queryable.SingleOrDefault(source,predicate)

    let thenBy keySelector comparer source = System.Linq.Queryable.ThenBy(source,keySelector,comparer)

    let thenByDescending keySelector comparer source = System.Linq.Queryable.ThenByDescending(source,keySelector,comparer)

    let union comparer source1 source2 = System.Linq.Queryable.Union(source1,source2,comparer)
