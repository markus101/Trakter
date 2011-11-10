using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Trakter.Models;
using Trakter.Models.Calendar;

namespace Trakter.Providers
{
    internal class CalendarProvider
    {
        private readonly HttpProvider _httpProvider;

        public CalendarProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual List<Day> GetPremieres(string apiKey, DateTime? startDate = null, int? days = null)
        {
            var url = String.Format("{0}{1}", Url.CalendarPremieres, apiKey);

            if (startDate.HasValue)
            {
                url += String.Format("/{0}", startDate.Value.ToString("yyyyMMdd"));

                if (days != null)
                    url += String.Format("/{0}", days);
            }

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<Day>();

            return JsonConvert.DeserializeObject<List<Day>>(responseJson);
        }

        public virtual List<Day> GetShows(string apiKey, DateTime? startDate = null, int? days = null)
        {
            var url = String.Format("{0}{1}", Url.CalendarShows, apiKey);

            if (startDate.HasValue)
            {
                url += String.Format("/{0}", startDate.Value.ToString("yyyyMMdd"));

                if (days != null)
                    url += String.Format("/{0}", days);
            }

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<Day>();

            return JsonConvert.DeserializeObject<List<Day>>(responseJson);
        }
    }
}
