using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace GraphQL
{
    public static class IResolveFieldContextExtensions
    {
        private static readonly IntGlobalId[] _defaultIntGlobalIds = new IntGlobalId[0];
        private static readonly StringGlobalId[] _defaultStringGlobalIds = new StringGlobalId[0];

        public static HashSet<int> GetIntIdsFromGlobalIdsArgument(this IResolveFieldContext ctx, string argumentName)
        {
            var arg = ctx.GetArgument(argumentName, _defaultIntGlobalIds);
            return new HashSet<int>(arg.Select(gid => gid.Id));
        }

        public static int? GetIntIdFromOptionalGlobalIdArgument(this IResolveFieldContext ctx, string argumentName)
        {
            return ctx.GetArgument<IntGlobalId>(argumentName)?.Id;
        }

        public static int GetIntIdFromGlobalIdArgument(this IResolveFieldContext ctx, string argumentName)
        {
            return ctx.GetArgument<IntGlobalId>(argumentName).Id;
        }

        public static HashSet<string> GetStringIdsFromGlobalIdsArgument(this IResolveFieldContext ctx, string argumentName)
        {
            var arg = ctx.GetArgument(argumentName, _defaultStringGlobalIds);
            return new HashSet<string>(arg.Select(gid => gid.Id));
        }

        public static string GetStringIdFromGlobalIdArgument(this IResolveFieldContext ctx, string argumentName)
        {
            return ctx.GetArgument<StringGlobalId>(argumentName).Id;
        }
    }
}
