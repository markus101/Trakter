using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;

namespace Trakter.Models.Movie
{
    public class TraktMovieSearch
    {
        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "tmdb_id")]
        public int? TmdbId { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? Duration { get; set; }
        public int? Progress { get; set; }

        [JsonProperty(PropertyName = "plugin_version")]
        public string PluginVersion { get; set; }

        [JsonProperty(PropertyName = "media_center_version")]
        public string MediaCenterVersion { get; set; }

        [JsonProperty(PropertyName = "media_center_date")]
        public string MediaCenterDate { get; set; }
        public int? Plays { get; set; }

        [JsonConverter(typeof(EpochDateTimeConverter))]
        [JsonProperty(PropertyName = "last_played")]
        public DateTime? LastPlayed { get; set; }

        public RatingType Rating { get; set; }
    }
}