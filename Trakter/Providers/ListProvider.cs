using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trakter.Models.Lists;

namespace Trakter.Providers
{
    public class ListProvider
    {
        private readonly HttpProvider _httpProvider;

        public ListProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual ListResult AddList(string apiKey, string username, string passwordHash, string name, ListPrivacyType privacy, string description = null)
        {
            var url = String.Format("{0}{1}", Url.ListsAdd, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("name", name));

            if (description != null)
                postJson.Add(new JProperty("description", description));

            postJson.Add(new JProperty("privacy", privacy.ToString().ToLower()));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<ListResult>(responseJson);
        }

        public virtual ListResult UpdateList(string apiKey, string username, string passwordHash, string slug, string name = null, ListPrivacyType? privacy = null, string description = null)
        {
            var url = String.Format("{0}{1}", Url.ListsUpdate, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("slug", slug));

            if (name != null)
                postJson.Add(new JProperty("name", name));

            if (description != null)
                postJson.Add(new JProperty("description", description));

            if (privacy.HasValue)
                postJson.Add(new JProperty("privacy", privacy.Value.ToString().ToLower()));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<ListResult>(responseJson);
        }

        public virtual ListItemResult DeleteListItems(string apiKey, string username, string passwordHash, string slug, List<dynamic> items)
        {
            var url = String.Format("{0}{1}", Url.ListsItemsDelete, apiKey);

            var request = new ListItemRequest { Username = username, Password = passwordHash, Slug = slug, Items = items };
            var postJson = Serializer.SerializeObject(request);
            var responseJson = _httpProvider.DownloadString(url, postJson);

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<ListItemResult>(responseJson);
        }

        public virtual ListResult DeleteList(string apiKey, string username, string passwordHash, string slug)
        {
            var url = String.Format("{0}{1}", Url.ListsDelete, apiKey);

            var postJson = new JObject();
            postJson.Add(new JProperty("username", username));
            postJson.Add(new JProperty("password", passwordHash));
            postJson.Add(new JProperty("slug", slug));

            var responseJson = _httpProvider.DownloadString(url, postJson.ToString());

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<ListResult>(responseJson);
        }

        public virtual ListItemResult AddListItems(string apiKey, string username, string passwordHash, string slug, List<dynamic> items)
        {
            var url = String.Format("{0}{1}", Url.ListsItemsAdd, apiKey);

            var request = new ListItemRequest { Username = username, Password = passwordHash, Slug = slug, Items = items };
            var postJson = Serializer.SerializeObject(request);
            var responseJson = _httpProvider.DownloadString(url, postJson);

            if (String.IsNullOrWhiteSpace(responseJson))
                return null;

            return JsonConvert.DeserializeObject<ListItemResult>(responseJson);
        }
    }
}
