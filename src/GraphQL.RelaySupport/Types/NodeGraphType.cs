using GraphQL.Resolvers;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GraphQL.Types
{
    public interface INodeGraphType
    {
        Task<object> GetByGlobalIdAsync(ResolveFieldContext<object> context, string id);
    }

    public static class NodeFieldNames
    {
        public const string Id = "id";
        public const string DbId = "dbId";
    }

    public abstract class NodeGraphType<TSourceType, TId> : ObjectGraphType<TSourceType>, INodeGraphType
    {
        protected NodeGraphType(Func<TSourceType, TId> idSelector, string dbIdDescription = null)
        {
            Interface<NodeInterface>();

            Field(
                name: NodeFieldNames.Id,
                description: "The object's global ID.",
                type: typeof(NonNullGraphType<IdGraphType>),
                resolve: context => GlobalIdParser.ToGlobalId(
                    context.ParentType.Name,
                    idSelector(context.Source)
                )
            );

            var dbIdfield = new FieldType
            {
                Name = NodeFieldNames.DbId,
                Description = $"Identifies the primary key from the database.{(string.IsNullOrWhiteSpace(dbIdDescription) ? null : $" {dbIdDescription}")}",
                Type = GetDbIdFieldType(),
                Resolver = new FuncFieldResolver<TSourceType, TId>(context => idSelector(context.Source)),
            };
            AddField(dbIdfield);
        }

        private Type GetDbIdFieldType()
        {
            // Most of these are handled automagically by Graph if you don't specify the type, except Guid,
            // but we'll just be explicit anyway so we can handle it in one way
            var dbIdType = typeof(TId);

            if (dbIdType == typeof(int))
            {
                return typeof(NonNullGraphType<IntGraphType>);
            }

            if (dbIdType == typeof(long))
            {
                return typeof(NonNullGraphType<IntGraphType>); // TODO: Change to LongGraphType after this: https://github.com/graphql-dotnet/graphql-dotnet/issues/1171
            }

            if (dbIdType == typeof(Guid))
            {
                return typeof(NonNullGraphType<GuidGraphType>);
            }

            if (dbIdType == typeof(string))
            {
                return typeof(NonNullGraphType<StringGraphType>);
            }

            throw new NotImplementedException($"Support for a NodeGraphType with id of type {dbIdType} doesn't exist yet.");
        }

        public async Task<object> GetByGlobalIdAsync(ResolveFieldContext<object> context, string id)
            => await GetByIdAsync(context, (TId)Convert.ChangeType(id, typeof(TId), CultureInfo.InvariantCulture));

        public abstract Task<TSourceType> GetByIdAsync(ResolveFieldContext<object> context, TId id);
    }
}
