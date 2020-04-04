using System;
using AutoMapper;

namespace GraphQL.RelaySupport.AutoMapped.Converters
{
    public class GlobalIdToGuidConverter : ITypeConverter<GuidGlobalId, Guid>
    {
        public Guid Convert(GuidGlobalId source, Guid destination, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
