using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Trakter.Models
{
    public class TraktShow
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Url { get; set; }

        [JsonProperty(PropertyName = "first_aired")]
        public long FirstAired { get; set; }

        public string Country { get; set; }
        public string Overview { get; set; }
        public int Runtime { get; set; }
        public string Network { get; set; }
        public string AirDay { get; set; }
        public string AirTime { get; set; }
        public string Certification { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "tvdb_id")]
        public int TvdbId { get; set; }

        [JsonProperty(PropertyName = "tvrage_id")]
        public int TvRageId { get; set; }

        public Images Images { get; set; }
        public Ratings Ratings { get; set; }

        //The Users own rating
        public RatingType Rating { get; set; }

        [JsonProperty(PropertyName = "in_watchlist")]
        public bool InWatchlist { get; set; }
    }
}
