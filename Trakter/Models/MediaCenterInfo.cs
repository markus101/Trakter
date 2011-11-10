using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;

namespace Trakter.Models
{
    public class MediaCenterInfo
    {
        [JsonProperty(PropertyName = "plugin_version")]
        public string PluginVersion { get; set; }

        [JsonProperty(PropertyName = "media_center_version")]
        public string MediaCenterVersion { get; set; }

        [JsonProperty(PropertyName = "media_center_date")]
        public string MediaCenterDate { get; set; }
    }
}