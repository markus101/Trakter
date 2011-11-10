using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Trakter.JsonConverters
{
    class TraktDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                var dt = Convert.ToDateTime(value);

                writer.WriteValue(dt.ToString("yyyy-MM-dd"));
            }

            else
            {
                throw new Exception("Expected date object value.");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is String)
                return DateTime.ParseExact(reader.Value.ToString(), "yyyy-MM-dd", null);

            throw new Exception("Expected string.");
        }
    }
}
