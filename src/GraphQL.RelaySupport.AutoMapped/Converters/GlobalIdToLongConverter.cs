using AutoMapper;

namespace GraphQL.RelaySupport.AutoMapped.Converters
{
    public class GlobalIdToLongConverter : ITypeConverter<LongGlobalId, long>
    {
        public long Convert(LongGlobalId source, long destination, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
