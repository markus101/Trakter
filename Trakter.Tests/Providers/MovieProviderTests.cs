using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMoq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Trakter.Models;
using Trakter.Models.Lists;
using Trakter.Models.Movie;
using Trakter.Providers;
using Trakter.Tests.Framework;

namespace Trakter.Tests.Providers
{
    [TestFixture]
    public class MovieProviderTests
    {
        [Test]
        public void CancelledWatching_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";

            var jsonResult = "{\"status\":\"success\",\"message\":\"cancelled watching\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().CancelWatching(Constants.ApiKey, "username", "sha1hash");

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("cancelled watching");
        }

        [Test]
        public void Scrobble_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"imdb_id\": \"tt0372784\",\"tmdb_id\": null,\"title\": \"Batman Begins\",\"year\": 2005,\"duration\": 141,\"progress\": 25,\"plugin_version\": \"1.0\",\"media_center_version\": \"10.0\",\"media_center_date\": \"Dec 17 2010\"}";

            var jsonResult = "{\"status\":\"success\",\"message\":\"scrobbled Batman Begins (2005)\"}";
            var movie = new TraktMovieSearch
                            {
                                ImdbId = "tt0372784",
                                Title = "Batman Begins",
                                Year = 2005,
                                Duration = 141,
                                Progress = 25,
                                PluginVersion = "1.0",
                                MediaCenterVersion = "10.0",
                                MediaCenterDate = "Dec 17 2010"
                            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Scrobble(Constants.ApiKey, "username", "sha1hash", movie);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("scrobbled Batman Begins (2005)");
        }

        [Test]
        public void Seen_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"movies\": [{\"imdb_id\": \"tt0114746\",\"tmdb_id\": null,\"title\": \"Twelve Monkeys\",\"year\": 1995,\"plays\": 1,\"last_played\": 1255917378}]}";

            var jsonResult = "{\"status\": \"success\",\"inserted\": 1,\"already_exist\": 0,\"already_exist_movies\": [],\"skipped\": 0,\"skipped_movies\": []}";
            var movie = new TraktMovieSearch
            {
                ImdbId = "tt0114746",
                Title = "Twelve Monkeys",
                Year = 1995,
                Plays = 1,
                LastPlayed = new DateTime(2009, 10, 19, 1, 56, 18)
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Seen(Constants.ApiKey, "username", "sha1hash", new List<TraktMovieSearch>{movie});

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Inserted.Should().Be(1);
            result.Already_Exist.Should().Be(0);
            result.Already_Exist_Movies.Should().BeEmpty();
            result.Skipped.Should().Be(0);
            result.Skipped_Movies.Should().BeEmpty();
        }

        [Test]
        public void Library_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"movies\": [{\"imdb_id\": \"tt0114746\",\"tmdb_id\": null,\"title\": \"Twelve Monkeys\",\"year\": 1995}]}";

            var jsonResult = "{\"status\": \"success\",\"inserted\": 1,\"already_exist\": 0,\"already_exist_movies\": [],\"skipped\": 0,\"skipped_movies\": []}";
            var movie = new TraktMovieSearch
            {
                ImdbId = "tt0114746",
                Title = "Twelve Monkeys",
                Year = 1995,
                Plays = 1,
                LastPlayed = new DateTime(2009, 10, 19, 1, 56, 18)
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Library(Constants.ApiKey, "username", "sha1hash", new List<TraktMovieSearch> { movie });

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Inserted.Should().Be(1);
            result.Already_Exist.Should().Be(0);
            result.Already_Exist_Movies.Should().BeEmpty();
            result.Skipped.Should().Be(0);
            result.Skipped_Movies.Should().BeEmpty();
        }

        [TestCase("tt0079470")]
        [TestCase("life-of-brian-1979")]
        [TestCase("583")]
        public void Shouts_should_return_shouts_when_movie_is_found(string movieSearch)
        {
            //Setup
            var jsonResult = File.ReadAllText(@".\Files\Movie_Shouts.txt");
            var expectedUrl = String.Format("{0}{1}/{2}", Url.MovieShouts, Constants.ApiKey, movieSearch);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Shouts(Constants.ApiKey, movieSearch);

            //Assert
            result.Should().HaveCount(1);
            result.First().Shout.Should().NotBeNullOrEmpty();
            result.First().User.Should().NotBeNull();
        }

        [Test]
        public void Summary_should_return_summary_without_user_specific_details_when_no_auth_is_provided()
        {
            //Setup
            var movieSearch = "tt1285016";
            var jsonResult = File.ReadAllText(@".\Files\Movie_Summary.txt");
            var expectedUrl = String.Format("{0}{1}/{2}", Url.MovieSummary, Constants.ApiKey, movieSearch);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Summary(Constants.ApiKey, movieSearch);

            //Assert
            result.Should().NotBeNull();
            result.Watched.Should().BeFalse();
            result.Plays.Should().Be(0);
            result.Rating.Should().Be(RatingType.Unrate);
            result.InWatchlist.Should().BeFalse();
            result.InCollection.Should().BeFalse();
        }

        [Test]
        public void Summary_should_return_summary_with_user_specific_details_when_auth_is_provided()
        {
            //Setup
            var movieSearch = "tt1285016";
            var jsonResult = File.ReadAllText(@".\Files\Movie_Summary_WithUserDetails.txt");
            var expectedUrl = String.Format("{0}{1}/{2}", Url.MovieSummary, Constants.ApiKey, movieSearch);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Summary(Constants.ApiKey, movieSearch, "username", "sha1hash");

            //Assert
            result.Should().NotBeNull();
            result.Watched.Should().BeTrue();
            result.Plays.Should().Be(3);
            result.Rating.Should().Be(RatingType.Love);
            result.InWatchlist.Should().BeTrue();
            result.InCollection.Should().BeTrue();
        }

        [Test]
        public void Unlibrary_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"movies\": [{\"imdb_id\": \"tt0114746\",\"tmdb_id\": null,\"title\": \"Twelve Monkeys\",\"year\": 1995}]}";

            var jsonResult = "{\"status\": \"success\",\"message\": \"1 movies removed from library\"}";
            var movie = new TraktMovieSearch
            {
                ImdbId = "tt0114746",
                Title = "Twelve Monkeys",
                Year = 1995,
                Plays = 1,
                LastPlayed = new DateTime(2009, 10, 19, 1, 56, 18)
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Unlibrary(Constants.ApiKey, "username", "sha1hash", new List<TraktMovieSearch> { movie });

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 movies removed from library");
        }

        [Test]
        public void Unseen_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"movies\": [{\"imdb_id\": \"tt0114746\",\"tmdb_id\": null,\"title\": \"Twelve Monkeys\",\"year\": 1995}]}";

            var jsonResult = "{\"status\": \"success\",\"message\": \"1 movies removed as seen\"}";
            var movie = new TraktMovieSearch
            {
                ImdbId = "tt0114746",
                Title = "Twelve Monkeys",
                Year = 1995,
                Plays = 1,
                LastPlayed = new DateTime(2009, 10, 19, 1, 56, 18)
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Unseen(Constants.ApiKey, "username", "sha1hash", new List<TraktMovieSearch> { movie });

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 movies removed as seen");
        }

        [Test]
        public void Unwatchlist_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"movies\": [{\"imdb_id\": \"tt0114746\",\"tmdb_id\": null,\"title\": \"Twelve Monkeys\",\"year\": 1995}]}";

            var jsonResult = "{\"status\": \"success\",\"message\": \"1 movies removed from watchlist\"}";
            var movie = new TraktMovieSearch
            {
                ImdbId = "tt0114746",
                Title = "Twelve Monkeys",
                Year = 1995,
                Plays = 1,
                LastPlayed = new DateTime(2009, 10, 19, 1, 56, 18)
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Unwatchlist(Constants.ApiKey, "username", "sha1hash", new List<TraktMovieSearch> { movie });

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 movies removed from watchlist");
        }

        [Test]
        public void Watching_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"imdb_id\": \"tt0372784\",\"tmdb_id\": null,\"title\": \"Batman Begins\",\"year\": 2005,\"duration\": 141,\"progress\": 25,\"plugin_version\": \"1.0\",\"media_center_version\": \"10.0\",\"media_center_date\": \"Dec 17 2010\"}";

            var jsonResult = "{\"status\":\"success\",\"message\":\"watching Batman Begins (2005)\"}";
            var movie = new TraktMovieSearch
            {
                ImdbId = "tt0372784",
                Title = "Batman Begins",
                Year = 2005,
                Duration = 141,
                Progress = 25,
                PluginVersion = "1.0",
                MediaCenterVersion = "10.0",
                MediaCenterDate = "Dec 17 2010"
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Scrobble(Constants.ApiKey, "username", "sha1hash", movie);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("watching Batman Begins (2005)");
        }

        [Test]
        public void WatchingNow_should_return_users_currently_watching_specified_movie_no_auth()
        {
            //Setup
            var movieSearch = "tt1285016";
            var jsonResult = "[{\"username\":\"anzerman\",\"protected\":false,\"full_name\":\"\",\"gender\":\"\",\"age\":\"\",\"location\":\"\",\"about\":\"\",\"joined\":1298695196,\"avatar\":\"http://vicmackey.trakt.tv/images/avatars/706.jpg\",\"url\":\"http://trakt.tv/user/anzerman\"}]";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.MovieWatchingNow, Constants.ApiKey, movieSearch);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().WatchingNow(Constants.ApiKey, movieSearch);

            //Assert
            result.Should().HaveCount(1);
        }

        [Test]
        public void WatchingNow_should_return_users_currently_watching_specified_movie_including_protected_friends()
        {
            //Setup
            var movieSearch = "tt1285016";
            var jsonResult = "[{\"username\":\"anzerman\",\"protected\":true,\"full_name\":\"\",\"gender\":\"\",\"age\":\"\",\"location\":\"\",\"about\":\"\",\"joined\":1298695196,\"avatar\":\"http://vicmackey.trakt.tv/images/avatars/706.jpg\",\"url\":\"http://trakt.tv/user/anzerman\"}]";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.MovieWatchingNow, Constants.ApiKey, movieSearch);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().WatchingNow(Constants.ApiKey, movieSearch, "username", "sha1hash");

            //Assert
            result.Should().HaveCount(1);
        }

        [Test]
        public void Watchlist_should_return_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"movies\": [{\"imdb_id\": \"tt0114746\",\"tmdb_id\": null,\"title\": \"Twelve Monkeys\",\"year\": 1995}]}";

            var jsonResult = "{\"status\": \"success\",\"inserted\": 1,\"already_exist\": 0,\"already_exist_movies\": [],\"skipped\": 0,\"skipped_movies\": []}";
            var movie = new TraktMovieSearch
            {
                ImdbId = "tt0114746",
                Title = "Twelve Monkeys",
                Year = 1995
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MovieProvider>().Watchlist(Constants.ApiKey, "username", "sha1hash", new List<TraktMovieSearch> { movie });

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Inserted.Should().Be(1);
            result.Already_Exist.Should().Be(0);
            result.Already_Exist_Movies.Should().BeEmpty();
            result.Skipped.Should().Be(0);
            result.Skipped_Movies.Should().BeEmpty();
        }
    }
}