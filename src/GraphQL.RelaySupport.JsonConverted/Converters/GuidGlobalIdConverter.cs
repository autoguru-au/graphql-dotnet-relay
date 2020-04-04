using System;
using Newtonsoft.Json;

namespace GraphQL.RelaySupport.NewtonsoftJson.Converters
{
    public class GuidGlobalIdConverter : JsonConverter<GuidGlobalId>
    {
        public override GuidGlobalId ReadJson(JsonReader reader, Type objectType, GuidGlobalId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new GuidGlobalId((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, GuidGlobalId value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
