using AutoMapper;

namespace GraphQL.RelaySupport.AutoMapped.Converters
{
    public class GlobalIdToStringConverter : ITypeConverter<StringGlobalId, string>
    {
        public string Convert(StringGlobalId source, string destination, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
