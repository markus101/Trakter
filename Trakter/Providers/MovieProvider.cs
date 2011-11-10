using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trakter.Models;
using Trakter.Models.Lists;
using Trakter.Models.Movie;
using Trakter.Models.User;

namespace Trakter.Providers
{
    public class MovieProvider
    {
        private readonly HttpProvider _httpProvider;

        public MovieProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual SimpleStatusResult CancelWatching(string apiKey, string username, string passwordHash)
        {
            var url = String.Format("{0}{1}", Url.MovieCancelWatching, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return new SimpleStatusResult { Status = ResultStatusType.Failure, Message = "Failed to send CancelWatching for Movie" };

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual SimpleStatusResult Scrobble(string apiKey, string username, string passwordHash, TraktMovieSearch movie)
        {
            var url = String.Format("{0}{1}", Url.MovieScrobble, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("imdb_id", movie.ImdbId));
            postJson.Add(new JProperty("tmdb_id", movie.TmdbId));
            postJson.Add(new JProperty("title", movie.Title));
            postJson.Add(new JProperty("year", movie.Year));
            postJson.Add(new JProperty("duration", movie.Duration));
            postJson.Add(new JProperty("progress", movie.Progress));
            postJson.Add(new JProperty("plugin_version", movie.PluginVersion));
            postJson.Add(new JProperty("media_center_version", movie.MediaCenterVersion));
            postJson.Add(new JProperty("media_center_date", movie.MediaCenterDate));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual MovieAddResult Seen(string apiKey, string username, string passwordHash, List<TraktMovieSearch> movies)
        {
            var url = String.Format("{0}{1}", Url.MovieSeen, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("movies", new JArray(from m in movies select new JObject(
                new JProperty("imdb_id", m.ImdbId),
                new JProperty("tmdb_id", m.TmdbId),
                new JProperty("title", m.Title),
                new JProperty("year", m.Year),
                new JProperty("plays", m.Plays),
                new JProperty("last_played", m.LastPlayed.Value.ToEpochTime())
                ))));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<MovieAddResult>(responseJson);
        }

        public virtual MovieAddResult Library(string apiKey, string username, string passwordHash, List<TraktMovieSearch> movies)
        {
            var url = String.Format("{0}{1}", Url.MovieLibrary, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("movies", new JArray(from m in movies
                                                            select new JObject(
                                                                new JProperty("imdb_id", m.ImdbId),
                                                                new JProperty("tmdb_id", m.TmdbId),
                                                                new JProperty("title", m.Title),
                                                                new JProperty("year", m.Year)
                                                                ))));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<MovieAddResult>(responseJson);
        }

        public virtual List<TraktShout> Shouts(string apiKey, string movie)
        {
            var url = String.Format("{0}{1}/{2}", Url.MovieShouts, apiKey, movie);

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<TraktShout>();

            return JsonConvert.DeserializeObject<List<TraktShout>>(responseJson);
        }

        public virtual MovieSummary Summary(string apiKey, string movie, string username = null, string passwordHash = null)
        {
            var url = String.Format("{0}{1}/{2}", Url.MovieSummary, apiKey, movie);

            string responseJson;

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(passwordHash))
            {
                //Create the Json!
                var postJson = new JObject();
                postJson.Add(new JProperty("username", username));
                postJson.Add(new JProperty("password", passwordHash));
                responseJson = _httpProvider.DownloadString(url, postJson.ToString());
            }

            else
                responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<MovieSummary>(responseJson);
        }

        public virtual SimpleStatusResult Unlibrary(string apiKey, string username, string passwordHash, List<TraktMovieSearch> movies)
        {
            var url = String.Format("{0}{1}", Url.MovieUnlibrary, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("movies", new JArray(from m in movies
                                                            select new JObject(
                                                                new JProperty("imdb_id", m.ImdbId),
                                                                new JProperty("tmdb_id", m.TmdbId),
                                                                new JProperty("title", m.Title),
                                                                new JProperty("year", m.Year)
                                                                ))));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual SimpleStatusResult Unseen(string apiKey, string username, string passwordHash, List<TraktMovieSearch> movies)
        {
            var url = String.Format("{0}{1}", Url.MovieUnseen, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("movies", new JArray(from m in movies
                                                            select new JObject(
                                                                new JProperty("imdb_id", m.ImdbId),
                                                                new JProperty("tmdb_id", m.TmdbId),
                                                                new JProperty("title", m.Title),
                                                                new JProperty("year", m.Year)
                                                                ))));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual SimpleStatusResult Unwatchlist(string apiKey, string username, string passwordHash, List<TraktMovieSearch> movies)
        {
            var url = String.Format("{0}{1}", Url.MovieUnwatchlist, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("movies", new JArray(from m in movies
                                                            select new JObject(
                                                                new JProperty("imdb_id", m.ImdbId),
                                                                new JProperty("tmdb_id", m.TmdbId),
                                                                new JProperty("title", m.Title),
                                                                new JProperty("year", m.Year)
                                                                ))));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual SimpleStatusResult Watching(string apiKey, string username, string passwordHash, TraktMovieSearch movie)
        {
            var url = String.Format("{0}{1}", Url.MovieWatching, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("imdb_id", movie.ImdbId));
            postJson.Add(new JProperty("tmdb_id", movie.TmdbId));
            postJson.Add(new JProperty("title", movie.Title));
            postJson.Add(new JProperty("year", movie.Year));
            postJson.Add(new JProperty("duration", movie.Duration));
            postJson.Add(new JProperty("progress", movie.Progress));
            postJson.Add(new JProperty("plugin_version", movie.PluginVersion));
            postJson.Add(new JProperty("media_center_version", movie.MediaCenterVersion));
            postJson.Add(new JProperty("media_center_date", movie.MediaCenterDate));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual List<TraktUser> WatchingNow(string apiKey, string movie, string username = null, string passwordHash = null)
        {
            var url = String.Format("{0}{1}/{2}", Url.MovieWatchingNow, apiKey, movie);
            string responseJson;

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(passwordHash))
            {
                var postJson = new JObject();
                postJson.Add(new JProperty("username", username));
                postJson.Add(new JProperty("password", passwordHash));

                responseJson = _httpProvider.DownloadString(url, postJson.ToString());
            }
            
            else
                responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<TraktUser>();

            return JsonConvert.DeserializeObject<List<TraktUser>>(responseJson);
        }

        public virtual MovieAddResult Watchlist(string apiKey, string username, string passwordHash, List<TraktMovieSearch> movies)
        {
            var url = String.Format("{0}{1}", Url.MovieWatchlist, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("movies", new JArray(from m in movies
                                                            select new JObject(
                                                                new JProperty("imdb_id", m.ImdbId),
                                                                new JProperty("tmdb_id", m.TmdbId),
                                                                new JProperty("title", m.Title),
                                                                new JProperty("year", m.Year)
                                                                ))));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<MovieAddResult>(responseJson);
        }
    }
}
