using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Trakter.Models;
using Trakter.Models.Calendar;
using Trakter.Models.Rate;

namespace Trakter.Providers
{
    internal class RateProvider
    {
        private readonly HttpProvider _httpProvider;

        public RateProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual RateResult Episode(string apiKey, RateEpisode episode)
        {
            var url = String.Format("{0}{1}", Url.RateEpisode, apiKey);
            var postJson = Serializer.SerializeObject(episode);
            var responseJson = _httpProvider.DownloadString(url, postJson);

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<RateResult>(responseJson);
        }

        public virtual RateResult Movie(string apiKey, RateMovie movie)
        {
            var url = String.Format("{0}{1}", Url.RateMovie, apiKey);
            var postJson = Serializer.SerializeObject(movie);
            var responseJson = _httpProvider.DownloadString(url, postJson);

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<RateResult>(responseJson);
        }

        public virtual RateResult Show(string apiKey, RateShow show)
        {
            var url = String.Format("{0}{1}", Url.RateShow, apiKey);
            var postJson = Serializer.SerializeObject(show);
            var responseJson = _httpProvider.DownloadString(url, postJson);

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<RateResult>(responseJson);
        }
    }
}
