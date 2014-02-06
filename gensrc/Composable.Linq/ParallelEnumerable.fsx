// Generated with ComposableExtensions (0.5) https://github.com/jbtule/ComposableExtensions

module Composable.Linq.ParallelEnumerable

let aggregate func source = System.Linq.ParallelEnumerable.Aggregate(source,func)

let all predicate source = System.Linq.ParallelEnumerable.All(source,predicate)

let any source = System.Linq.ParallelEnumerable.Any(source)

let asEnumerable source = System.Linq.ParallelEnumerable.AsEnumerable(source)

let asSequential source = System.Linq.ParallelEnumerable.AsSequential(source)

let asUnordered source = System.Linq.ParallelEnumerable.AsUnordered(source)

let cast source = System.Linq.ParallelEnumerable.Cast(source)

let contains value source = System.Linq.ParallelEnumerable.Contains(source,value)

let count source = System.Linq.ParallelEnumerable.Count(source)

let defaultIfEmpty source = System.Linq.ParallelEnumerable.DefaultIfEmpty(source)

let distinct source = System.Linq.ParallelEnumerable.Distinct(source)

let elementAt index source = System.Linq.ParallelEnumerable.ElementAt(source,index)

let elementAtOrDefault index source = System.Linq.ParallelEnumerable.ElementAtOrDefault(source,index)

let first source = System.Linq.ParallelEnumerable.First(source)

let firstOrDefault source = System.Linq.ParallelEnumerable.FirstOrDefault(source)

let forAll action source = System.Linq.ParallelEnumerable.ForAll(source,action)

let groupBy keySelector source = System.Linq.ParallelEnumerable.GroupBy(source,keySelector)

let last source = System.Linq.ParallelEnumerable.Last(source)

let lastOrDefault source = System.Linq.ParallelEnumerable.LastOrDefault(source)

let longCount source = System.Linq.ParallelEnumerable.LongCount(source)

let ofType source = System.Linq.ParallelEnumerable.OfType(source)

let orderBy keySelector source = System.Linq.ParallelEnumerable.OrderBy(source,keySelector)

let orderByDescending keySelector source = System.Linq.ParallelEnumerable.OrderByDescending(source,keySelector)

let reverse source = System.Linq.ParallelEnumerable.Reverse(source)

let single source = System.Linq.ParallelEnumerable.Single(source)

let singleOrDefault source = System.Linq.ParallelEnumerable.SingleOrDefault(source)

let skip count source = System.Linq.ParallelEnumerable.Skip(source,count)

let take count source = System.Linq.ParallelEnumerable.Take(source,count)

let thenBy keySelector source = System.Linq.ParallelEnumerable.ThenBy(source,keySelector)

let thenByDescending keySelector source = System.Linq.ParallelEnumerable.ThenByDescending(source,keySelector)

let toArray source = System.Linq.ParallelEnumerable.ToArray(source)

let toDictionary keySelector source = System.Linq.ParallelEnumerable.ToDictionary(source,keySelector)

let toList source = System.Linq.ParallelEnumerable.ToList(source)

let toLookup keySelector source = System.Linq.ParallelEnumerable.ToLookup(source,keySelector)

let withCancellation cancellationToken source = System.Linq.ParallelEnumerable.WithCancellation(source,cancellationToken)

let withDegreeOfParallelism degreeOfParallelism source = System.Linq.ParallelEnumerable.WithDegreeOfParallelism(source,degreeOfParallelism)

let withExecutionMode executionMode source = System.Linq.ParallelEnumerable.WithExecutionMode(source,executionMode)

let withMergeOptions mergeOptions source = System.Linq.ParallelEnumerable.WithMergeOptions(source,mergeOptions)

module Full =

    let aggregate seed func resultSelector source = System.Linq.ParallelEnumerable.Aggregate(source,seed,func,resultSelector)

    let any predicate source = System.Linq.ParallelEnumerable.Any(source,predicate)

    let contains value comparer source = System.Linq.ParallelEnumerable.Contains(source,value,comparer)

    let count predicate source = System.Linq.ParallelEnumerable.Count(source,predicate)

    let defaultIfEmpty defaultValue source = System.Linq.ParallelEnumerable.DefaultIfEmpty(source,defaultValue)

    let distinct comparer source = System.Linq.ParallelEnumerable.Distinct(source,comparer)

    let first predicate source = System.Linq.ParallelEnumerable.First(source,predicate)

    let firstOrDefault predicate source = System.Linq.ParallelEnumerable.FirstOrDefault(source,predicate)

    let groupBy keySelector elementSelector resultSelector comparer source = System.Linq.ParallelEnumerable.GroupBy(source,keySelector,elementSelector,resultSelector,comparer)

    let last predicate source = System.Linq.ParallelEnumerable.Last(source,predicate)

    let lastOrDefault predicate source = System.Linq.ParallelEnumerable.LastOrDefault(source,predicate)

    let longCount predicate source = System.Linq.ParallelEnumerable.LongCount(source,predicate)

    let orderBy keySelector comparer source = System.Linq.ParallelEnumerable.OrderBy(source,keySelector,comparer)

    let orderByDescending keySelector comparer source = System.Linq.ParallelEnumerable.OrderByDescending(source,keySelector,comparer)

    let single predicate source = System.Linq.ParallelEnumerable.Single(source,predicate)

    let singleOrDefault predicate source = System.Linq.ParallelEnumerable.SingleOrDefault(source,predicate)

    let thenBy keySelector comparer source = System.Linq.ParallelEnumerable.ThenBy(source,keySelector,comparer)

    let thenByDescending keySelector comparer source = System.Linq.ParallelEnumerable.ThenByDescending(source,keySelector,comparer)

    let toDictionary keySelector elementSelector comparer source = System.Linq.ParallelEnumerable.ToDictionary(source,keySelector,elementSelector,comparer)

    let toLookup keySelector elementSelector comparer source = System.Linq.ParallelEnumerable.ToLookup(source,keySelector,elementSelector,comparer)
