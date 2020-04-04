using System;
using Newtonsoft.Json;

namespace GraphQL.RelaySupport.NewtonsoftJson.Converters
{
    public class IntGlobalIdConverter : JsonConverter<IntGlobalId>
    {
        public override IntGlobalId ReadJson(JsonReader reader, Type objectType, IntGlobalId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new IntGlobalId((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, IntGlobalId value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
