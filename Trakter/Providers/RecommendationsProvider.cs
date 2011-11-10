using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trakter.Models;
using Trakter.Models.Calendar;
using Trakter.Models.Genres;
using Trakter.Models.Movie;
using Trakter.Models.Recommendations;

namespace Trakter.Providers
{
    internal class RecommendationsProvider
    {
        private readonly HttpProvider _httpProvider;

        public RecommendationsProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual List<MovieRecommendation> Movies(string apiKey, string username, string passwordHash, Genre genre = null, int startYear = 0, int endYear = 0)
        {
            var url = String.Format("{0}{1}", Url.RecommendationsMovies, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            if (genre != null)
                postJson.Add(new JProperty("genre", genre.Slug));

            if (startYear > 0)
                postJson.Add(new JProperty("startYear", startYear));

            if (endYear > 0)
                postJson.Add(new JProperty("endYear", startYear));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<MovieRecommendation>();

            return JsonConvert.DeserializeObject<List<MovieRecommendation>>(responseJson);
        }

        public virtual DismissMovieResult DismissMovie(string apiKey, string username, string passwordHash, string imdbId = null, int? tmdbId = null, string title = null, int? year = null)
        {
            var url = String.Format("{0}{1}", Url.RecommendationsMoviesDismiss, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            if (imdbId != null)
                postJson.Add(new JProperty("imdb_id", imdbId));

            if (tmdbId != null)
                postJson.Add(new JProperty("tmdb_id", tmdbId));

            if (title != null)
                postJson.Add(new JProperty("title", title));

            if (year != null)
                postJson.Add(new JProperty("year", year));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<DismissMovieResult>(responseJson);
        }

        public virtual List<ShowRecommendation> Shows(string apiKey, string username, string passwordHash, Genre genre = null, int startYear = 0, int endYear = 0)
        {
            var url = String.Format("{0}{1}", Url.RecommendationsShows, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            if (genre != null)
                postJson.Add(new JProperty("genre", genre.Slug));

            if (startYear > 0)
                postJson.Add(new JProperty("startYear", startYear));

            if (endYear > 0)
                postJson.Add(new JProperty("endYear", startYear));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<ShowRecommendation>();

            return JsonConvert.DeserializeObject<List<ShowRecommendation>>(responseJson);
        }

        public virtual DismissMovieResult DismissShow(string apiKey, string username, string passwordHash, string imdbId = null, int? tvdbId = null, string title = null, int? year = null)
        {
            var url = String.Format("{0}{1}", Url.RecommendationsShowsDismiss, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            if (imdbId != null)
                postJson.Add(new JProperty("imdb_id", imdbId));

            if (tvdbId != null)
                postJson.Add(new JProperty("tvdb_id", tvdbId));

            if (title != null)
                postJson.Add(new JProperty("title", title));

            if (year != null)
                postJson.Add(new JProperty("year", year));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<DismissMovieResult>(responseJson);
        }
    }
}
