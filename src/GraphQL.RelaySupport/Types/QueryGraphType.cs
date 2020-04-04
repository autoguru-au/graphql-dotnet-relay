using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Types
{
    public class QueryGraphType : ObjectGraphType
    {
        private static class ArgumentNames
        {
            public const string Id = "id";
            public const string Ids = "ids";
        }

        public QueryGraphType()
        {
            Name = "Query";

            Field<NodeInterface>()
                .Name("node")
                .Description("Fetches an object given its global ID.")
                .Argument<NonNullGraphType<IdGraphType>>(ArgumentNames.Id, "The global ID of the object.")
                .ResolveAsync(ResolveNodeAsync);

            Field<NonNullGraphType<ListGraphType<NodeInterface>>>()
                .Name("nodes")
                .Description("Lookup nodes by a list of global IDs.")
                .Argument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>>(ArgumentNames.Ids, "The list of global IDs.")
                .ResolveAsync(ResolveNodesAsync);
        }

        private Task<object> ResolveNodeAsync(ResolveFieldContext<object> context)
        {
            var globalId = context.GetArgument<string>(ArgumentNames.Id);
            return GetNodeByGlobalIdAsync(context, globalId);
        }

        private async Task<object> ResolveNodesAsync(ResolveFieldContext<object> context)
        {
            // TODO: Is there any way we could make this more optimal?
            // Maybe by batching IDs into common types and then having a GetByGlobalIdsAsync on each INodeGraphType implementor...
            var globalIds = context.GetArgument<string[]>(ArgumentNames.Ids);
            var getNodeTasks = globalIds.Select(globalId => GetNodeByGlobalIdAsync(context, globalId));
            return await Task.WhenAll(getNodeTasks);
        }

        private static Task<object> GetNodeByGlobalIdAsync(ResolveFieldContext<object> context, string globalId)
        {
            var (typeName, id) = GlobalIdParser.FromGlobalId(globalId);
            var node = (INodeGraphType)context.Schema.FindType(typeName);
            return node.GetByGlobalIdAsync(context, id);
        }
    }
}
