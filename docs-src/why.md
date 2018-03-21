Why Composable: From C# to F#
=============================


In C# we define static functions:

    [lang=csharp]
    public static int Add(int y, int x){
      return x + y;
    }
    public static int AddOne(int x){
      return Add(x, 1);
    }
    public static int AddTwo(int x){
      return Add(x, 2);
    }

When combining these functions it looks like this:

    [lang=csharp]
    AddTwo(AddOne(4)); // 7

Not very readable.

>We cram functions into objects so that
>code reads from left to right. Method chaining in F#
>and Clojure accomplishes this more flexibly.
>–Jessica Kerr (@jessitron) [March 3, 2014](https://twitter.com/jessitron/statuses/440276780520177664)

So when we do this in F#

    let add y x = x + y
    let addOne = add 1
    let addTwo = add 2
    4 |> addOne |> addTwo

*output:*

    val it : int = 7

it works very cleanly, because the functions are in curried form.
`Add` doesn't take two arguments, it takes one argument
and returns a function that takes takes 1 argument and returns a
result.

You can see manually do curried form in C# but the
final invocation is still clunky.

    [lang=csharp]
    public static Func<int,int> Add(int y){
      return x => x + y;
    }
    var addOne = Add(1);
    var addTwo = Add(2);
    addTwo(addOne(4)); // 7



However there is a way to do left to right in C#
without resorting  to objects...Extension Methods:

    [lang=csharp]
    public static int Add(this int x, int y){
      return x + y;
    }
    public static int AddOne(this int x){
        return x.Add(1);
    }
    public static int AddTwo(this int x){
        return x.Add(2);
    }

Giving us left to right

    [lang=csharp]
    4.AddOne().AddTwo(); // 7

And thusly is the basis for the method chaining api of LINQ.

    [lang=csharp]
    Enumerable.Range(1,5).Where(x => x < 3); // 1,2

In F# we already can do the equivalent

    seq { 1..5 }
      |> Seq.filter (fun x -> x < 3)

*output:*

    val it : mkSeq@543<int> = seq [1; 2]


However, if we add a little bit more complexity to the C# LINQ

    [lang=csharp]
    new [] {
    	new {FirstName = "Stella", LastName = "Gibson"},
    	new {FirstName = "Paul", LastName = "Spector"},
    	new {FirstName = "Danielle", LastName = "Ferrington"},
    	new {FirstName = "Olivia", LastName = "Spector"},
    }.OrderByDescending(x=>x.LastName).ThenBy(x=>x.FirstName);

The F# idomatic built-in list comprehension is not as robust

    open System

    type Person = { FirstName : string; LastName: string; }

    let lastThenFirst (x:Person) (y:Person) =
      let cmp = -String.Compare(x.LastName, y.LastName)
      if cmp = 0 then
        String.Compare(x.FirstName, y.FirstName)
      else
        cmp

    [
      {FirstName="Stella"; LastName="Gibson"}
      {FirstName = "Paul"; LastName = "Spector"}
      {FirstName = "Danielle"; LastName = "Ferrington"}
      {FirstName = "Olivia"; LastName = "Spector"}
    ]
      |> List.sortWith lastThenFirst

*output:*

    val it : list<Person> =
         [{FirstName = "Olivia";LastName = "Spector";};
          {FirstName = "Paul"; LastName = "Spector";};
          {FirstName = "Stella";LastName = "Gibson";};
          {FirstName = "Danielle"; LastName = "Ferrington";}]

You can use LINQ directly, Extension Methods are supported
 in F# 3.0 along with Type Directed Conversions
at Member Invocations.

    open System.Linq

    type Person = { FirstName : string; LastName: string; }

    [
      {FirstName="Stella"; LastName="Gibson"}
      {FirstName = "Paul"; LastName = "Spector"}
      {FirstName = "Danielle"; LastName = "Ferrington"}
      {FirstName = "Olivia"; LastName = "Spector"}
    ].OrderByDescending(fun x -> x.LastName).ThenBy(fun x -> x.FirstName)

*output:*

    val it : OrderedEnumerable<Person, string> = seq
      [{FirstName = "Olivia"; LastName = "Spector";};
       {FirstName = "Paul"; LastName = "Spector";};
       {FirstName = "Stella"; LastName = "Gibson";};
       {FirstName = "Danielle"; LastName = "Ferrington";}]

It's not idiomatic F# syntax. It looks like C# (just with more "fun")


But it is static, immutable and lazy.

So we have a pattern with left to right with both
C# extension methods and curried form F#.

So given an extension method `(this, arg) -> value` it could be reformed
into `arg -> this -> value` and it would syntactically look like an F# API.

Examples

    let inline orderByDescending (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.OrderByDescending(source, System.Func<'TSource, 'TKey>(keySelector))
    let inline thenBy (keySelector:'TSource->'TKey) source = System.Linq.Enumerable.ThenBy(source, System.Func<'TSource, 'TKey>(keySelector))

And this is the basis for FSharp.Interop.Compose we can make .NET BCL api's
that have idiomatic F# behavior look, read, write like idiomatic F# api's.

    open Composable.Linq

    type Person = { FirstName : string; LastName: string; }

    [
      {FirstName="Stella"; LastName="Gibson"}
      {FirstName = "Paul"; LastName = "Spector"}
      {FirstName = "Danielle"; LastName = "Ferrington"}
      {FirstName = "Olivia"; LastName = "Spector"}
    ]
      |> Enumerable.orderByDescending (fun x -> x.LastName)
      |> Enumerable.thenBy (fun x -> x.FirstName)

*output:*

    val it : OrderedEnumerable<Person, string> =
        seq [{FirstName = "Olivia"; LastName = "Spector";};
             {FirstName = "Paul"; LastName = "Spector";};
             {FirstName = "Stella"; LastName = "Gibson";};
             {FirstName = "Danielle"; LastName = "Ferrington";}]

  See also these StackOverflow questions

   - [Is there an F# equivalent of Enumerable.DefaultIfEmpty?](http://stackoverflow.com/a/21558989/637783)
   - [efficient way to create map of lists in functional style](http://stackoverflow.com/q/22178238/637783)
