using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Trakter.Models.Shout
{
    public class ShoutShow
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonProperty(PropertyName = "tvdb_id")]
        public int TvdbId { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        public string Title { get; set; }
        public int Year { get; set; }
        public string Shout { get; set; }
    }
}
