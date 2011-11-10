using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trakter.Models;
using Trakter.Models.Lists;
using Trakter.Models.Movie;
using Trakter.Models.Movies;
using Trakter.Models.User;

namespace Trakter.Providers
{
    public class MoviesProvider
    {
        private readonly HttpProvider _httpProvider;

        public MoviesProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual List<TrendingMovie> Trending(string apiKey, string username = null, string passwordHash = null)
        {
            var url = String.Format("{0}{1}", Url.MoviesTrending, apiKey);

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
                return new List<TrendingMovie>();

            return JsonConvert.DeserializeObject<List<TrendingMovie>>(responseJson);
        }
    }
}
