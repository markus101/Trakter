using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Trakter
{
    internal static class Serializer
    {
        internal static string SerializeObject(Object value)
        {
            var settings = new JsonSerializerSettings();

            //Convert all properties to lower-case
            settings.ContractResolver = new LowercaseContractResolver();

            //Do not include properties with null values
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.SerializeObject(value, Formatting.None, settings);
        }
    }
}
