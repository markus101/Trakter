using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakter.Models;

namespace Trakter.JsonConverters
{
    class ResultStatusTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ResultStatusType)
                writer.WriteValue(value.ToString());

            else
                throw new Exception("Expected ResultStatusType object value.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ResultStatusType type;

            if (Enum.TryParse(reader.Value.ToString(), true, out type))
                return type;

            throw new Exception("Invalid ResultStatus Type!");
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(ResultStatusType))
                return true;

            return false;
        }
    }
}
