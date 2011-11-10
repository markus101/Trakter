using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;
using Trakter.Models.Persons;
using Trakter.Models.User;

namespace Trakter.Models.Recommendations
{
    public class MovieRecommendation
    {
        public string Title { get; set; }
        public int Year { get; set; }

        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Released { get; set; }
        public string Url { get; set; }
        public int Runtime { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public string Certification { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "tmdb_id")]
        public int TmdbId { get; set; }

        public Images Images { get; set; }
        public Ratings Ratings { get; set; }
    }
}
