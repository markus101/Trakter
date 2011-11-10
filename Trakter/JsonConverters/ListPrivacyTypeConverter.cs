using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakter.Models.Lists;

namespace Trakter.JsonConverters
{
    class ListPrivacyTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ListPrivacyType)
                writer.WriteValue(value.ToString());

            else
                throw new Exception("Expected ListPrivacyType object value.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ListPrivacyType type;

            if (Enum.TryParse(reader.Value.ToString(), true, out type))
                return type;

            throw new Exception("Invalid Privacy Type!");
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(ListPrivacyType))
                return true;

            return false;
        }
    }
}
