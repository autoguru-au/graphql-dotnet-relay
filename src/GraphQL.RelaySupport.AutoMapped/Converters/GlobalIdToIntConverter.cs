using AutoMapper;

namespace GraphQL.RelaySupport.AutoMapped.Converters
{
    public class GlobalIdToIntConverter : ITypeConverter<IntGlobalId, int>
    {
        public int Convert(IntGlobalId source, int destination, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
