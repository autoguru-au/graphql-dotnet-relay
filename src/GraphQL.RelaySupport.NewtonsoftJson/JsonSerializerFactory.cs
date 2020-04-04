using GraphQL.RelaySupport.NewtonsoftJson.Converters;
using Newtonsoft.Json;

namespace GraphQL.RelaySupport.NewtonsoftJson
{
    public static class JsonSerializerFactory
    {
        public static JsonSerializer Create()
        {
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new GuidGlobalIdConverter());
            jsonSerializer.Converters.Add(new IntGlobalIdConverter());
            jsonSerializer.Converters.Add(new LongGlobalIdConverter());
            jsonSerializer.Converters.Add(new StringGlobalIdConverter());
            return jsonSerializer;
        }
    }
}
