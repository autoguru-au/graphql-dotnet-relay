using System;
using Newtonsoft.Json;

namespace GraphQL.RelaySupport.NewtonsoftJson.Converters
{
    public class LongGlobalIdConverter : JsonConverter<LongGlobalId>
    {
        public override LongGlobalId ReadJson(JsonReader reader, Type objectType, LongGlobalId existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new LongGlobalId((string)reader.Value);
        }

        public override void WriteJson(JsonWriter writer, LongGlobalId value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
