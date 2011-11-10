using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.Models.Genres;

namespace Trakter.Providers
{
    public class GenreProvider
    {
        private readonly HttpProvider _httpProvider;

        public GenreProvider(HttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public virtual List<Genre> GetMovieGenres(string apiKey)
        {
            var url = String.Format("{0}{1}", Url.GenresMovies, apiKey);

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<Genre>();

            return JsonConvert.DeserializeObject<List<Genre>>(responseJson);
        }

        public virtual List<Genre> GetShowGenres(string apiKey)
        {
            var url = String.Format("{0}{1}", Url.GenresShows, apiKey);

            var responseJson = _httpProvider.DownloadString(url);

            if (String.IsNullOrWhiteSpace(responseJson))
                return new List<Genre>();

            return JsonConvert.DeserializeObject<List<Genre>>(responseJson);
        }
    }
}
