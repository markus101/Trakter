using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;
using Trakter.Models.Persons;
using Trakter.Models.User;

namespace Trakter.Models.Movies
{
    public class TrendingMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }

        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Released { get; set; }
        public string Url { get; set; }
        public string Trailer { get; set; }
        public int Runtime { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public string Certification { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "tmdb_id")]
        public int TmdbId { get; set; }

        public Images Images { get; set; }

        public int Watchers { get; set; }

        public Ratings Ratings { get; set; }

        //If Auth is passed in
        public bool Watched { get; set; }
        public int Plays { get; set; }
        public RatingType Rating { get; set; }

        [JsonProperty(PropertyName = "in_watchlist")]
        public bool InWatchlist { get; set; }

        [JsonProperty(PropertyName = "in_collection")]
        public bool InCollection { get; set; }
    }
}
