using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;

namespace Trakter.Models.Lists
{
    public class ListResult
    {
        public ResultStatusType Status { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        [JsonConverter(typeof(ListPrivacyTypeConverter))]
        public ListPrivacyType Privacy { get; set; }
    }
}
