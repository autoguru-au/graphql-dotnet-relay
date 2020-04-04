using System;
using Newtonsoft.Json;

namespace GraphQL.RelaySupport.NewtonsoftJson.Converters
{
    public class StringGlobalIdConverter : JsonConverter<StringGlobalId>
    {
        public override StringGlobalId ReadJson(JsonReader reader, Type objectType, StringGlobalId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new StringGlobalId((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, StringGlobalId value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
