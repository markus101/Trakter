using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;

namespace Trakter.Models
{
    [JsonConverter(typeof(RatingTypeConverter))]
    public enum RatingType
    {
        Hate = -1,
        Unrate = 0,
        Love = 1
    }
}
