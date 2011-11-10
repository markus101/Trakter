using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Trakter.Models.Shout
{
    public class ShoutMovie
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "tmdb_id")]
        public int? TmdbId { get; set; }

        public string Title { get; set; }
        public int Year { get; set; }
        public string Shout { get; set; }
    }
}
