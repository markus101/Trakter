using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;

namespace Trakter.Models
{
    public class TraktEpisode
    {
        public string Title { get; set; }
        public int Season { get; set; }
        public int Number { get; set; }
        public string Overview { get; set; }
        public string Url { get; set; }

        [JsonProperty(PropertyName = "first_aired")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime FirstAired { get; set; }

        public Images Images { get; set; }
        public Ratings Ratings { get; set; }

        [JsonProperty(PropertyName = "tvdb_id")]
        public int TvdbId { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        public bool? Watched { get; set; }
        public int? Plays { get; set; }
        public RatingType? Rating { get; set; }

        [JsonProperty(PropertyName = "in_watchlist")]
        public bool InWatchlist { get; set; }
    }
}
