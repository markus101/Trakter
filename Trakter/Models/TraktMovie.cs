using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;

namespace Trakter.Models
{
    public class TraktMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Released { get; set; }
        
        public string Url { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public string Certification { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "tmdb_id")]
        public int TvdbId { get; set; }

        public Images Images { get; set; }
    }
}
