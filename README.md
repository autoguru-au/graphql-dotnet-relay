# graphql-dotnet-relay
This library provides useful bits for graphql-dotnet based servers to add relay support. 

## Features

### Node support
Relay requires that:
1. all queryable types in your graph implement a base type `Node`, and
2. are queryable via query fields of form `node(id: ID!)` and `nodes(ids: [ID!]!)`.

We offer two classes to make this easy for you.

#### `QueryGraphType`
Use this as the base for your root `query` field you attach to your schema and 
It'll add the `node` and `nodes` fields mentioned above.

#### `NodeGraphType<TSourceType, TId>`
Use this as the base for your own types, instead of `ObjectGraphType<TSourceType>` and 
it'll add two fields, `id` and `dbId` (where `id` is the Relay-spec compliant field required by all `Node` types,
and `dbId` is your own internal id for that type, that you may need for displaying in your UI).

### `ID` support

#### Translations
Although an `ID` is great for Relay, it's not great for humans or for use in our internal code. 
Furthermore, once you jump on the Relay train, you'll want to replace all your id-referencing field arguments with `ID!`

That causes a few issues:
1. How can I query for data when dev'ing without first getting the global ID?
   1. Similarly, I want my website's URLs to contain my friendlier id, like /blog/1, how can I call graph with that without first translating that into a global ID?
2. How can I migrate to Relay support gradually without all my clients breaking by passing `1` or `"1"`?
3. How can I deserialize a global `ID` in my resolver to a value I understand internally to resolve my data?

To make this easier, we:
1. Hookup wiring to support parsing `string` or `TId` into a `ID`, so you can safely pass "1" or `1` in place of a real global `ID`.
2. Provide extension methods you can use in your resolver to read global `ID`s into the real id you know and love.

There's also a `GlobalIdParser` if you ever need to work with global IDs yourself.

#### Strongly-typed `ID` classes
We offer some built-in types for variations of global IDs (e.g. `GuidGlobalId`, `IntGlobalId`, `LongGlobalId`, `StringGlobalId`)
so that you can read a complex field argument as a DTO class and use properties like `IntGlobalId`.

#### AutoMapper converters
If you're using AutoMapper to translate between say an `InputDto` and another type,
you can have a DTO with a `IntGlobalId` property and map that to a type with an `int` property.

#### NewtonsoftJson converters
Similar to above but for NewtonsoftJson. Call `JsonSerializerFactory.Create()` to get a serializer that can read/write 
these ID-types into the equivalent BCL type to work with. Or use them like you would any other
Newtonsoft.Json converter.

### JSResource field
...incoming

## Setup

Install from NuGet:
```asdf```

In your `Startup.cs`:
1. Call `services.AddRelaySupport();`
2. For AutoMapper support, include our profile when registering it, `services.AddAutoMapper(..., typeof(GlobalIdsProfile))`

Update your root Query type to inherit from `QueryGraphType`.

For each of your relevant graph types:
1. Inherit from `NodeGraphType<TSourceType, TId>`, specifying `TId` as the type you use internally, e.g. `int`.
2. Call base constructor, passing an `idSelector` func, e.g. `myType => myType.Id`.
3. Implement the abstract `GetByIdAsync` method, which will receive the real database id of your type.

In your field resolvers:
* If you want an id/s argument, use `context.GetIntIdFromGlobalIdArgument("argName")` or relevant overload.
* If you want a complex argument, use standard `context.GetArgument<T>` from `GraphQL` project, but use the strongly-typed `ID` classes on your propeties where needed.

## License

MIT &copy; [AutoGuru](https://www.autoguru.com.au/)

<a href="http://www.autoguru.com.au/"><img src="https://cdn.autoguru.com.au/images/logos/autoguru.svg" alt="AutoGuru" width="150" /></a>
