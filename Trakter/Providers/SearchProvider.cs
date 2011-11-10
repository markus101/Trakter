using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Trakter.Models;
using Trakter.Models.Calendar;
using Trakter.Models.Search;

namespace Trakter.Providers
{
    internal class SearchProvider
    {
        private readonly HttpProvider _httpProvider;

        public SearchProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual List<EpisodeSearchResult> Episodes(string apiKey, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("SearchTerm must be a valid string", searchTerm);

            var url = String.Format("{0}{1}/{2}", Url.SearchEpisodes, apiKey, HttpUtility.UrlEncode(searchTerm));

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<EpisodeSearchResult>();

            return JsonConvert.DeserializeObject<List<EpisodeSearchResult>>(responseJson);
        }

        public virtual List<TraktMovie> Movies(string apiKey, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("SearchTerm must be a valid string", searchTerm);

            var url = String.Format("{0}{1}/{2}", Url.SearchMovies, apiKey, HttpUtility.UrlEncode(searchTerm));

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<TraktMovie>();

            return JsonConvert.DeserializeObject<List<TraktMovie>>(responseJson);
        }

        public virtual List<PeopleSearchResult> People(string apiKey, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("SearchTerm must be a valid string", searchTerm);

            var url = String.Format("{0}{1}/{2}", Url.SearchPeople, apiKey, HttpUtility.UrlEncode(searchTerm));

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<PeopleSearchResult>();

            return JsonConvert.DeserializeObject<List<PeopleSearchResult>>(responseJson);
        }

        public virtual List<TraktShow> Shows(string apiKey, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("SearchTerm must be a valid string", searchTerm);

            var url = String.Format("{0}{1}/{2}", Url.SearchShows, apiKey, HttpUtility.UrlEncode(searchTerm));

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<TraktShow>();

            return JsonConvert.DeserializeObject<List<TraktShow>>(responseJson);
        }

        public virtual List<TraktUser> Users(string apiKey, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("SearchTerm must be a valid string", searchTerm);

            var url = String.Format("{0}{1}/{2}", Url.SearchUsers, apiKey, HttpUtility.UrlEncode(searchTerm));

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<TraktUser>();

            return JsonConvert.DeserializeObject<List<TraktUser>>(responseJson);
        }
    }
}
