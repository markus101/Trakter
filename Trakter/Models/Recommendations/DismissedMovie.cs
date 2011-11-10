using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Trakter.Models.Recommendations
{
    public class DismissedMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "tmdb_id")]
        public int TmdbId { get; set; }
    }
}
