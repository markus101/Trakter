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
using Trakter.Models.Show;
using Trakter.Providers;
using Trakter.Tests.Framework;

namespace Trakter.Tests.Providers
{
    [TestFixture]
    public class ShowProviderTests
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
            var result = mocker.Resolve<ShowProvider>().CancelWatching(Constants.ApiKey, "username", "sha1hash");

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("cancelled watching");
        }

        [Test]
        public void EpisodeAction_should_return_success_for_Library()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowEpisodeLibrary, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007,\"episodes\": [{\"season\": 1,\"episode\": 1}]}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes added to your library\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Library,
                                                                        new List<SeasonEpisodePair> { new SeasonEpisodePair { Season = 1, Episode = 1 } },
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes added to your library");
        }

        [Test]
        public void EpisodeAction_should_return_success_for_Seen()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowEpisodeSeen, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007,\"episodes\": [{\"season\": 1,\"episode\": 1}]}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes marked as seen\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Seen,
                                                                        new List<SeasonEpisodePair> { new SeasonEpisodePair { Season = 1, Episode = 1 } }, 
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes marked as seen");
        }

        [Test]
        public void EpisodeAction_should_return_success_for_Watchlist()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowEpisodeWatchlist, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007,\"episodes\": [{\"season\": 1,\"episode\": 1}]}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes added to watched list\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Watchlist,
                                                                        new List<SeasonEpisodePair> { new SeasonEpisodePair { Season = 1, Episode = 1 } },
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes added to watched list");
        }

        [Test]
        public void EpisodeAction_should_return_success_for_Unlibrary()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowEpisodeUnlibrary, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007,\"episodes\": [{\"season\": 1,\"episode\": 1}]}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes removed from your library\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Unlibrary,
                                                                        new List<SeasonEpisodePair> { new SeasonEpisodePair { Season = 1, Episode = 1 } },
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes removed from your library");
        }

        [Test]
        public void EpisodeAction_should_return_success_for_Unseen()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowEpisodeUnseen, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007,\"episodes\": [{\"season\": 1,\"episode\": 1}]}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes marked as unseen\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Unseen,
                                                                        new List<SeasonEpisodePair> { new SeasonEpisodePair { Season = 1, Episode = 1 } },
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes marked as unseen");
        }

        [Test]
        public void EpisodeAction_should_return_success_for_Unwatchlist()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowEpisodeUnwatchlist, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007,\"episodes\": [{\"season\": 1,\"episode\": 1}]}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes removed from watched list\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Unwatchlist,
                                                                        new List<SeasonEpisodePair> { new SeasonEpisodePair { Season = 1, Episode = 1 } },
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes removed from watched list");
        }

        [Test]
        public void Shouts_should_return_shouts_for_episode()
        {
            //Setup
            var show = "the-walking-dead";
            var season = 1;
            var episode = 1;

            var jsonResult = File.ReadAllText(@".\Files\Episode_Shouts.txt");
            var expectedUrl = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeShouts, Constants.ApiKey, show, season, episode);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().Shouts(Constants.ApiKey, show, season, episode);

            //Assert
            result.Should().HaveCount(2);
            result.First().Shout.Should().NotBeNullOrEmpty();
            result.First().User.Should().NotBeNull();
            result.First().User.Age.Should().Be(27);
        }

        [Test]
        public void Summary_should_return_summary_for_episode()
        {
            //Setup
            var show = "the-league";
            var season = 1;
            var episode = 1;

            var jsonResult = File.ReadAllText(@".\Files\Episode_Summary.txt");
            var expectedUrl = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeSummary, Constants.ApiKey, show, season, episode);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeSummary(Constants.ApiKey, show, season, episode);

            //Assert
            result.Should().NotBeNull();
            result.Episode.Should().NotBeNull();
            result.Show.Should().NotBeNull();
            result.Episode.Title.Should().Be("The Draft");
            result.Show.Url.Should().Be("http://trakt.tv/show/the-league");
            result.Episode.Plays.Should().Be(null);
            result.Show.Rating.Should().Be(RatingType.Unrate);
        }

        [Test]
        public void Summary_should_return_summary_for_episode_with_user_details()
        {
            //Setup
            var show = "the-league";
            var season = 1;
            var episode = 1;

            var jsonResult = File.ReadAllText(@".\Files\Episode_Summary_WithUserDetails.txt");
            var expectedUrl = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeSummary, Constants.ApiKey, show, season, episode);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeSummary(Constants.ApiKey, show, season, episode);

            //Assert
            result.Should().NotBeNull();
            result.Episode.Should().NotBeNull();
            result.Show.Should().NotBeNull();
            result.Episode.Title.Should().Be("The Draft");
            result.Show.Url.Should().Be("http://trakt.tv/show/the-league");
            result.Episode.Plays.Should().Be(1);
            result.Show.Rating.Should().Be(RatingType.Love);

        }

        [Test]
        public void EpisodeWatchingNow_should_return_summary_for_episode()
        {
            //Setup
            var show = "the-league";
            var season = 1;
            var episode = 1;

            var jsonResult = "[{\"username\":\"anzerman\",\"protected\":false,\"full_name\":\"\",\"gender\":\"\",\"age\":\"\",\"location\":\"\",\"about\":\"\",\"joined\":1298695196,\"avatar\":\"http://vicmackey.trakt.tv/images/avatars/706.jpg\",\"url\":\"http://trakt.tv/user/anzerman\"}]";
            var expectedUrl = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeWatchingNow, Constants.ApiKey, show, season, episode);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeWatchingNow(Constants.ApiKey, show, season, episode);

            //Assert
            result.Should().NotBeEmpty();
            result.First().Protected.Should().BeFalse();
            result.First().Age.Should().Be(null);
        }

        [Test]
        public void EpisodeWatchingNow_should_return_summary_for_episode_with_friend_details()
        {
            //Setup
            var show = "the-league";
            var season = 1;
            var episode = 1;

            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";
            var jsonResult = "[{\"username\":\"anzerman\",\"protected\":true,\"full_name\":\"\",\"gender\":\"\",\"age\":\"22\",\"location\":\"\",\"about\":\"\",\"joined\":1298695196,\"avatar\":\"http://vicmackey.trakt.tv/images/avatars/706.jpg\",\"url\":\"http://trakt.tv/user/anzerman\"}]";
            var expectedUrl = String.Format("{0}{1}/{2}/{3}/{4}", Url.ShowEpisodeWatchingNow, Constants.ApiKey, show, season, episode);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().EpisodeWatchingNow(Constants.ApiKey, show, season, episode, "username", "sha1hash");

            //Assert
            result.Should().NotBeEmpty();
            result.First().Protected.Should().BeTrue();
            result.First().Age.Should().Be(22);
        }

        [Test]
        public void ShowAction_should_return_success_for_Library()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowLibrary, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes added to your library\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().ShowAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Library,
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes added to your library");
        }

        [Test]
        public void ShowAction_should_return_success_for_Seen()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowSeen, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes marked as seen\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().ShowAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Seen,
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes marked as seen");
        }

        [Test]
        public void ShowAction_should_return_success_for_Watchlist()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowWatchlist, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes added to watched list\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().ShowAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Watchlist,
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes added to watched list");
        }

        [Test]
        public void ShowAction_should_return_success_for_Unlibrary()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowUnlibrary, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes removed from your library\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().ShowAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Unlibrary,
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes removed from your library");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShowAction_should_return_success_for_Unseen()
        {
            //Setup
            var mocker = new AutoMoqer();

            //Act
            var result = mocker.Resolve<ShowProvider>().ShowAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Unseen,
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );
        }

        [Test]
        public void ShowAction_should_return_success_for_Unwatchlist()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShowUnwatchlist, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80379,\"imdb_id\": \"tt0898266\",\"title\": \"The Big Bang Theory\",\"year\": 2007}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"1 episodes removed from watched list\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().ShowAction(
                                                                        Constants.ApiKey,
                                                                        "username",
                                                                        "sha1hash",
                                                                        ActionType.Unwatchlist,
                                                                        80379,
                                                                        "tt0898266",
                                                                        "The Big Bang Theory",
                                                                        2007
                                                                    );

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("1 episodes removed from watched list");
        }

        [Test]
        public void Related_should_return_list_of_TraktShow()
        {
            //Setup
            var show = "the-league";

            var jsonResult = File.ReadAllText(@".\Files\Show_Related.txt");
            var expectedUrl = String.Format("{0}{1}/{2}", Url.ShowRelated, Constants.ApiKey, show);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().Related(Constants.ApiKey, show);

            //Assert
            result.Should().HaveCount(1);
        }

        [Test]
        public void Related_should_return_list_of_TraktShow_with_user_details()
        {
            //Setup
            var show = "the-league";
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";

            var jsonResult = File.ReadAllText(@".\Files\Show_Related_WithUserDetails.txt");
            var expectedUrl = String.Format("{0}{1}/{2}", Url.ShowRelated, Constants.ApiKey, show);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().Related(Constants.ApiKey, show, "username", "sha1hash");

            //Assert
            result.Should().HaveCount(1);
        }

        [Test]
        public void Related_should_return_list_of_TraktShow_with_user_details_hideWatched()
        {
            //Setup
            var show = "the-league";
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";

            var jsonResult = "[]";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.ShowRelated, Constants.ApiKey, show);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().Related(Constants.ApiKey, show, "username", "sha1hash");

            //Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void Scrobble_should_return_list_of_TraktShow_with_user_details_hideWatched()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 153021,\"imdb_id\": \"tt1520211\",\"title\": \"The Walking Dead\",\"year\": 2010,\"season\": 1,\"episode\": 1,\"duration\": 60,\"progress\": 25,\"plugin_version\": \"1.0\",\"media_center_version\": \"10.0\",\"media_center_date\": \"Dec 17 2010\"}";

            var jsonResult = "{\"status\": \"success\",\"message\": \"scrobbled The Walking Dead 1x01\"}";
            var expectedUrl = String.Format("{0}{1}", Url.ShowScrobble, Constants.ApiKey);

            var episodeInfo = new EpisodeInfo
                                  {
                                      Title = "The Walking Dead",
                                      Year = 2010,
                                      TvdbId = 153021,
                                      ImdbId = "tt1520211",
                                      Season = 1,
                                      Episode = 1
                                  };

            var mediaCenterInfo = new MediaCenterInfo
                                      {
                                          PluginVersion = "1.0",
                                          MediaCenterVersion = "10.0",
                                          MediaCenterDate = "Dec 17 2010"
                                      };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().Scrobble(Constants.ApiKey, "username", "sha1hash", episodeInfo, 60, 25, mediaCenterInfo);

            //Assert
            result.Should().NotBeNull();;
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("scrobbled The Walking Dead 1x01");
        }

        [Test]
        public void Season_should_return_list_of_TraktShow()
        {
            //Setup
            var show = "the-walking-dead";

            var jsonResult = File.ReadAllText(@".\Files\Show_Season.txt");
            var expectedUrl = String.Format("{0}{1}/{2}/{3}", Url.ShowSeason, Constants.ApiKey, show, 1);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().Season(Constants.ApiKey, show, 1);

            //Assert
            result.Should().HaveCount(6);
        }

        [Test]
        public void Season_should_return_list_of_TraktShow_with_user_details()
        {
            //Setup
            var show = "the-walking-dead";
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";

            var jsonResult = File.ReadAllText(@".\Files\Show_Season_WithUserDetails.txt");
            var expectedUrl = String.Format("{0}{1}/{2}/{3}", Url.ShowSeason, Constants.ApiKey, show, 1);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ShowProvider>().Season(Constants.ApiKey, show, 1, "username", "sha1hash");

            //Assert
            result.Should().HaveCount(6);
        }
    }
}