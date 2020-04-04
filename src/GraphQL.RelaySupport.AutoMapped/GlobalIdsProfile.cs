using System;
using AutoMapper;
using GraphQL.RelaySupport.AutoMapped.Converters;

namespace GraphQL.RelaySupport.AutoMapped
{
    public class GlobalIdsProfile : Profile
    {
        public GlobalIdsProfile()
        {
            CreateMap<IntGlobalId, int>().ConvertUsing<GlobalIdToIntConverter>();
            CreateMap<LongGlobalId, long>().ConvertUsing<GlobalIdToLongConverter>();
            CreateMap<StringGlobalId, string>().ConvertUsing<GlobalIdToStringConverter>();
            CreateMap<GuidGlobalId, Guid>().ConvertUsing<GlobalIdToGuidConverter>();
        }
    }
}
