using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;
using Trakter.Models.User;

namespace Trakter.Models
{
    public class TraktShout
    {
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Inserted { get; set; }

        public string Shout { get; set; }

        public TraktUser User { get; set; }
    }
}
