using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakter.JsonConverters;

namespace Trakter.Models.Calendar
{
    public class Day
    {
        //Date in YMD (2011-01-31)
        [JsonConverter(typeof(TraktDateTimeConverter))]
        public DateTime Date { get; set; }

        //Number of days
        public List<ShowAndEpisode> Episodes { get; set; }
    }
}
