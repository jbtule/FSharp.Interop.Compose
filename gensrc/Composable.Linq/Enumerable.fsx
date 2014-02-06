// Generated with ComposableExtensions (0.5) https://github.com/jbtule/ComposableExtensions

module Composable.Linq.Enumerable

let aggregate func source = System.Linq.Enumerable.Aggregate(source,func)

let all predicate source = System.Linq.Enumerable.All(source,predicate)

let any source = System.Linq.Enumerable.Any(source)

let asEnumerable source = System.Linq.Enumerable.AsEnumerable(source)

let cast source = System.Linq.Enumerable.Cast(source)

let concat first second = System.Linq.Enumerable.Concat(first,second)

let contains value source = System.Linq.Enumerable.Contains(source,value)

let count source = System.Linq.Enumerable.Count(source)

let defaultIfEmpty source = System.Linq.Enumerable.DefaultIfEmpty(source)

let distinct source = System.Linq.Enumerable.Distinct(source)

let elementAt index source = System.Linq.Enumerable.ElementAt(source,index)

let elementAtOrDefault index source = System.Linq.Enumerable.ElementAtOrDefault(source,index)

let except first second = System.Linq.Enumerable.Except(first,second)

let first source = System.Linq.Enumerable.First(source)

let firstOrDefault source = System.Linq.Enumerable.FirstOrDefault(source)

let groupBy keySelector source = System.Linq.Enumerable.GroupBy(source,keySelector)

let groupJoin outerKeySelector innerKeySelector resultSelector outer inner = System.Linq.Enumerable.GroupJoin(outer,inner,outerKeySelector,innerKeySelector,resultSelector)

let intersect first second = System.Linq.Enumerable.Intersect(first,second)

let join outerKeySelector innerKeySelector resultSelector outer inner = System.Linq.Enumerable.Join(outer,inner,outerKeySelector,innerKeySelector,resultSelector)

let last source = System.Linq.Enumerable.Last(source)

let lastOrDefault source = System.Linq.Enumerable.LastOrDefault(source)

let longCount source = System.Linq.Enumerable.LongCount(source)

let ofType source = System.Linq.Enumerable.OfType(source)

let orderBy keySelector source = System.Linq.Enumerable.OrderBy(source,keySelector)

let orderByDescending keySelector source = System.Linq.Enumerable.OrderByDescending(source,keySelector)

let reverse source = System.Linq.Enumerable.Reverse(source)

let sequenceEqual first second = System.Linq.Enumerable.SequenceEqual(first,second)

let single source = System.Linq.Enumerable.Single(source)

let singleOrDefault source = System.Linq.Enumerable.SingleOrDefault(source)

let skip count source = System.Linq.Enumerable.Skip(source,count)

let take count source = System.Linq.Enumerable.Take(source,count)

let thenBy keySelector source = System.Linq.Enumerable.ThenBy(source,keySelector)

let thenByDescending keySelector source = System.Linq.Enumerable.ThenByDescending(source,keySelector)

let toArray source = System.Linq.Enumerable.ToArray(source)

let toDictionary keySelector source = System.Linq.Enumerable.ToDictionary(source,keySelector)

let toList source = System.Linq.Enumerable.ToList(source)

let toLookup keySelector source = System.Linq.Enumerable.ToLookup(source,keySelector)

let union first second = System.Linq.Enumerable.Union(first,second)

let zip resultSelector first second = System.Linq.Enumerable.Zip(first,second,resultSelector)

module Full =

    let aggregate seed func resultSelector source = System.Linq.Enumerable.Aggregate(source,seed,func,resultSelector)

    let any predicate source = System.Linq.Enumerable.Any(source,predicate)

    let contains value comparer source = System.Linq.Enumerable.Contains(source,value,comparer)

    let count predicate source = System.Linq.Enumerable.Count(source,predicate)

    let defaultIfEmpty defaultValue source = System.Linq.Enumerable.DefaultIfEmpty(source,defaultValue)

    let distinct comparer source = System.Linq.Enumerable.Distinct(source,comparer)

    let except comparer first second = System.Linq.Enumerable.Except(first,second,comparer)

    let first predicate source = System.Linq.Enumerable.First(source,predicate)

    let firstOrDefault predicate source = System.Linq.Enumerable.FirstOrDefault(source,predicate)

    let groupBy keySelector elementSelector resultSelector comparer source = System.Linq.Enumerable.GroupBy(source,keySelector,elementSelector,resultSelector,comparer)

    let groupJoin outerKeySelector innerKeySelector resultSelector comparer outer inner = System.Linq.Enumerable.GroupJoin(outer,inner,outerKeySelector,innerKeySelector,resultSelector,comparer)

    let intersect comparer first second = System.Linq.Enumerable.Intersect(first,second,comparer)

    let join outerKeySelector innerKeySelector resultSelector comparer outer inner = System.Linq.Enumerable.Join(outer,inner,outerKeySelector,innerKeySelector,resultSelector,comparer)

    let last predicate source = System.Linq.Enumerable.Last(source,predicate)

    let lastOrDefault predicate source = System.Linq.Enumerable.LastOrDefault(source,predicate)

    let longCount predicate source = System.Linq.Enumerable.LongCount(source,predicate)

    let orderBy keySelector comparer source = System.Linq.Enumerable.OrderBy(source,keySelector,comparer)

    let orderByDescending keySelector comparer source = System.Linq.Enumerable.OrderByDescending(source,keySelector,comparer)

    let sequenceEqual comparer first second = System.Linq.Enumerable.SequenceEqual(first,second,comparer)

    let single predicate source = System.Linq.Enumerable.Single(source,predicate)

    let singleOrDefault predicate source = System.Linq.Enumerable.SingleOrDefault(source,predicate)

    let thenBy keySelector comparer source = System.Linq.Enumerable.ThenBy(source,keySelector,comparer)

    let thenByDescending keySelector comparer source = System.Linq.Enumerable.ThenByDescending(source,keySelector,comparer)

    let toDictionary keySelector elementSelector comparer source = System.Linq.Enumerable.ToDictionary(source,keySelector,elementSelector,comparer)

    let toLookup keySelector elementSelector comparer source = System.Linq.Enumerable.ToLookup(source,keySelector,elementSelector,comparer)

    let union comparer first second = System.Linq.Enumerable.Union(first,second,comparer)
