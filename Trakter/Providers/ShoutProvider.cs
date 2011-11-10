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
using Trakter.Models.Shout;

namespace Trakter.Providers
{
    internal class ShoutProvider
    {
        private readonly HttpProvider _httpProvider;

        public ShoutProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual SimpleStatusResult SendShout(string apiKey, object shout)
        {
            if (shout == null)
                throw new ArgumentException("Shout must be a valid shout object", "shout");

            string url = String.Empty;

            //Check for valid shout type
            if (shout is ShoutEpisode)
                url = String.Format("{0}{1}", Url.ShoutEpisode, apiKey);

            else if (shout is ShoutMovie)
                url = String.Format("{0}{1}", Url.ShoutMovie, apiKey);

            else if (shout is ShoutShow)
                url = String.Format("{0}{1}", Url.ShoutShow, apiKey);

            else
                throw new ArgumentException("Shout is an invalid type.", "shout");

            var postJson = Serializer.SerializeObject(shout);

            var responseJson = _httpProvider.DownloadString(url, postJson);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new SimpleStatusResult { Status = ResultStatusType.Failure, Message = "Failed to add shout." };

            return JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);
        }
    }
}
