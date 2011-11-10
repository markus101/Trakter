using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakter.Models;

namespace Trakter.JsonConverters
{
    class RatingTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is RatingType)
                writer.WriteValue(value.ToString().ToLower());

            else
                throw new Exception("Expected RatingType object value.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            RatingType type;

            if (Enum.TryParse(reader.Value.ToString(), true, out type))
                return type;

            throw new Exception("Invalid Rating Type!");
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(RatingType))
                return true;

            return false;
        }
    }
}
