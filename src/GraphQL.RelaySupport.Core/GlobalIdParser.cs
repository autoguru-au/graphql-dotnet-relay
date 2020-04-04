using System;
using System.Globalization;
using System.Text;

namespace GraphQL
{
    public static class GlobalIdParser
    {
        public static string ToGlobalId(string typeName, object id)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{typeName}:{id}"));

        private static string[] GetParts(string globalId)
            => Encoding.UTF8.GetString(Convert.FromBase64String(globalId)).Split(':');

        public static (string TypeName, string Id) FromGlobalId(string globalId)
        {
            var parts = GetParts(globalId);
            return (parts[0], parts[1]);
        }

        public static (string TypeName, TId Id) FromValue<TId>(string value)
        {
            var parts = GetParts(value);
            var id = (TId)Convert.ChangeType(parts[1], typeof(TId), CultureInfo.InvariantCulture);
            return (parts[0], id);
        }

        public static int GetIntIdFromValue(string value)
        {
            if (int.TryParse(value, out var id))
            {
                return id;
            }

            try
            {
                return FromValue<int>(value).Id;
            }
            catch
            {
                // swallow intentionally
                return default;
            }
        }

        public static long GetLongIdFromValue(string value)
        {
            if (long.TryParse(value, out var id))
            {
                return id;
            }

            try
            {
                return FromValue<long>(value).Id;
            }
            catch
            {
                // swallow intentionally
                return default;
            }
        }

        public static Guid GetGuidIdFromValue(string value)
        {
            if (Guid.TryParse(value, out var id))
            {
                return id;
            }

            try
            {
                return FromValue<Guid>(value).Id;
            }
            catch
            {
                // swallow intentionally
                return default;
            }
        }

        public static string GetStringIdFromValue(string value)
        {
            try
            {
                return FromValue<string>(value).Id;
            }
            catch
            {
                // swallow intentionally
                return value;
            }
        }
    }
}
