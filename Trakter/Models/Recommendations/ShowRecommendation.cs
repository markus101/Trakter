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
    public class ShowRecommendation
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Url { get; set; }

        [JsonConverter(typeof(EpochDateTimeConverter))]
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime FirstAired { get; set; }

        public string Country { get; set; }
        public string Overview { get; set; }
        public int Runtime { get; set; }
        public string Certification { get; set; }

        [JsonProperty(PropertyName = "tvdb_id")]
        public int TvdbId { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        public Images Images { get; set; }
        public Ratings Ratings { get; set; }
    }
}
