using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;

namespace Trakter.Models
{
    [JsonConverter(typeof(ResultStatusTypeConverter))]
    public enum ResultStatusType
    {
        Failure = 0,
        Success = 1
    }
}
