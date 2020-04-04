using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRelaySupport(this IServiceCollection services)
        {
            ValueConverter.Register(typeof(string), typeof(IntGlobalId), ParseStringToIntGlobalId);
            ValueConverter.Register(typeof(int), typeof(IntGlobalId), ParseIntToIntGlobalId);

            ValueConverter.Register(typeof(string), typeof(LongGlobalId), ParseStringToLongGlobalId);
            ValueConverter.Register(typeof(long), typeof(LongGlobalId), ParseLongToLongGlobalId);

            ValueConverter.Register(typeof(string), typeof(GuidGlobalId), ParseStringToGuidGlobalId);
            ValueConverter.Register(typeof(Guid), typeof(GuidGlobalId), ParseGuidToGuidGlobalId);

            ValueConverter.Register(typeof(string), typeof(StringGlobalId), ParseStringGlobalId);

            return services.AddSingleton<NodeInterface>();
        }

        private static object ParseStringToIntGlobalId(object value) => new IntGlobalId((string)value);
        private static object ParseIntToIntGlobalId(object value) => new IntGlobalId((int)value);

        private static object ParseStringToLongGlobalId(object value) => new LongGlobalId((string)value);
        private static object ParseLongToLongGlobalId(object value) => new LongGlobalId((long)value);

        private static object ParseStringToGuidGlobalId(object value) => new GuidGlobalId((string)value);
        private static object ParseGuidToGuidGlobalId(object value) => new GuidGlobalId((Guid)value);

        private static object ParseStringGlobalId(object value) => new StringGlobalId((string)value);
    }
}
