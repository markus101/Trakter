using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Trakter.Models.Search
{
    public class PeopleSearchResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }

        [JsonProperty(PropertyName = "tmdb_id")]
        public int TmdbId { get; set; }

        public Images Images { get; set; }
    }
}
