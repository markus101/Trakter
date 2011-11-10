using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trakter.Models;
using Trakter.Models.Show;

namespace Trakter.Providers
{
    public class ShowProvider
    {
        private readonly HttpProvider _httpProvider;

        public ShowProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual SimpleStatusResult CancelWatching(string apiKey, string username, string passwordHash)
        {
            var url = String.Format("{0}{1}", Url.ShowCancelWatching, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return new SimpleStatusResult { Status = ResultStatusType.Failure, Message = "Failed to send CancelWatching for Show" };

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual SimpleStatusResult EpisodeAction(string apiKey, string username, string passwordHash, ActionType action, List<SeasonEpisodePair> episodes, int tvdbId = 0, string imdbId = null, string title = null, int year = 0)
        {
            string url = String.Empty;

            if (action == ActionType.Library)
                url = String.Format("{0}{1}", Url.ShowEpisodeLibrary, apiKey);

            if (action == ActionType.Seen)
                url = String.Format("{0}{1}", Url.ShowEpisodeSeen, apiKey);

            if (action == ActionType.Watchlist)
                url = String.Format("{0}{1}", Url.ShowEpisodeWatchlist, apiKey);

            if (action == ActionType.Unlibrary)
                url = String.Format("{0}{1}", Url.ShowEpisodeUnlibrary, apiKey);

            if (action == ActionType.Unseen)
                url = String.Format("{0}{1}", Url.ShowEpisodeUnseen, apiKey);

            if (action == ActionType.Unwatchlist)
                url = String.Format("{0}{1}", Url.ShowEpisodeUnwatchlist, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            if (tvdbId != 0)
                postJson.Add(new JProperty("tvdb_id", tvdbId));

            if (imdbId != null)
                postJson.Add(new JProperty("imdb_id", imdbId));

            if (title != null)
                postJson.Add(new JProperty("title", title));

            if (year != 0)
                postJson.Add(new JProperty("year", year));

            postJson.Add(new JProperty("episodes", from e in episodes
                                                            select new JObject(
                                                                new JProperty("season", e.Season),
                                                                new JProperty("episode", e.Episode)
                                                                )));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return new SimpleStatusResult { Status = ResultStatusType.Failure, Message = "Failed to set " + action + " for episode(s)" };

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual List<TraktShout> Shouts(string apiKey, string show, int season, int episode)
        {
            var url = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeShouts, apiKey, show, season, episode);

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<TraktShout>();

            return JsonConvert.DeserializeObject<List<TraktShout>>(responseJson);
        }

        public virtual EpisodeSummary EpisodeSummary(string apiKey, string show, int season, int episode, string username = null, string passwordHash = null)
        {
            var url = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeSummary, apiKey, show, season, episode);
            string responseJson = String.Empty;

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
                return null;

            return JsonConvert.DeserializeObject<EpisodeSummary>(responseJson);
        }

        public virtual List<TraktUser> EpisodeWatchingNow(string apiKey, string show, int season, int episode, string username = null, string passwordHash = null)
        {
            var url = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeWatchingNow, apiKey, show, season, episode);
            string responseJson = String.Empty;

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

        public virtual SimpleStatusResult ShowAction(string apiKey, string username, string passwordHash, ActionType action, int tvdbId = 0, string imdbId = null, string title = null, int year = 0)
        {
            string url = String.Empty;

            if (action == ActionType.Library)
                url = String.Format("{0}{1}", Url.ShowLibrary, apiKey);

            if (action == ActionType.Seen)
                url = String.Format("{0}{1}", Url.ShowSeen, apiKey);

            if (action == ActionType.Watchlist)
                url = String.Format("{0}{1}", Url.ShowWatchlist, apiKey);

            if (action == ActionType.Unlibrary)
                url = String.Format("{0}{1}", Url.ShowUnlibrary, apiKey);

            if (action == ActionType.Unseen)
                throw new InvalidOperationException("No Trakt method for Show/Unseen");

            if (action == ActionType.Unwatchlist)
                url = String.Format("{0}{1}", Url.ShowUnwatchlist, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            if (tvdbId != 0)
                postJson.Add(new JProperty("tvdb_id", tvdbId));

            if (imdbId != null)
                postJson.Add(new JProperty("imdb_id", imdbId));

            if (title != null)
                postJson.Add(new JProperty("title", title));

            if (year != 0)
                postJson.Add(new JProperty("year", year));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return new SimpleStatusResult { Status = ResultStatusType.Failure, Message = "Failed to set " + action + " for show." };

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual List<TraktShow> Related(string apiKey, string show, string username = null, string passwordHash = null, bool hideWatched = false)
        {
            string url = String.Format("{0}{1}/{2}", Url.ShowRelated, apiKey, show);
            string responseJson = String.Empty;

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(passwordHash))
            {
                var postJson = new JObject();
                postJson.Add(new JProperty("username", username));
                postJson.Add(new JProperty("password", passwordHash));

                if (hideWatched)
                    url += "/true";

                responseJson = _httpProvider.DownloadString(url, postJson.ToString());
            }

            else
                responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<TraktShow>();

            return JsonConvert.DeserializeObject<List<TraktShow>>(responseJson);
        }

        public virtual SimpleStatusResult Scrobble(string apiKey, string username, string passwordHash, EpisodeInfo episodeInfo, int duration, int progress, MediaCenterInfo mediaCenterInfo)
        {
            string url = String.Format("{0}{1}", Url.ShowScrobble, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));

            if (episodeInfo.TvdbId != 0)
                postJson.Add(new JProperty("tvdb_id", episodeInfo.TvdbId));

            if (episodeInfo.ImdbId != null)
                postJson.Add(new JProperty("imdb_id", episodeInfo.ImdbId));

            if (episodeInfo.Title != null)
                postJson.Add(new JProperty("title", episodeInfo.Title));

            if (episodeInfo.Year != 0)
                postJson.Add(new JProperty("year", episodeInfo.Year));

            postJson.Add(new JProperty("season", episodeInfo.Season));
            postJson.Add(new JProperty("episode", episodeInfo.Episode));
            postJson.Add(new JProperty("duration", duration));
            postJson.Add(new JProperty("progress", progress));

            postJson.Add(new JProperty("plugin_version", mediaCenterInfo.PluginVersion));
            postJson.Add(new JProperty("media_center_version", mediaCenterInfo.MediaCenterVersion));
            postJson.Add(new JProperty("media_center_date", mediaCenterInfo.MediaCenterDate));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return new SimpleStatusResult { Status = ResultStatusType.Failure, Message = "Failed to scrobble." };

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }

        public virtual List<TraktEpisode> Season(string apiKey, string show, int season, string username = null, string passwordHash = null)
        {
            string url = String.Format("{0}{1}/{2}/{3}", Url.ShowSeason, apiKey, show, season);
            string responseJson = String.Empty;

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
                return new List<TraktEpisode>();

            return JsonConvert.DeserializeObject<List<TraktEpisode>>(responseJson);
        }
    }
}
