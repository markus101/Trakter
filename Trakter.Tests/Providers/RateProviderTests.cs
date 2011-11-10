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
using Trakter.Models.Rate;
using Trakter.Providers;
using Trakter.Tests.Framework;

namespace Trakter.Tests.Providers
{
    [TestFixture]
    public class RateProviderTests
    {
        [Test]
        public void RateEpsiode_should_return_RateResult_on_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 213221,\"title\": \"Portlandia\",\"year\": 2011,\"season\": 1,\"episode\": 1,\"rating\": \"love\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"rated Portlandia 1x01\",\"type\":\"episode\",\"rating\":\"love\",\"ratings\":{\"percentage\":100,\"votes\":2,\"loved\":2,\"hated\":0},\"facebook\":true,\"twitter\":true,\"tumblr\":false}";

            var episode = new RateEpisode
                              {
                                  Username = "username",
                                  Password = "sha1hash",
                                  TvdbId = 213221,
                                  Title = "Portlandia",
                                  Year = 2011,
                                  Season = 1,
                                  Episode = 1,
                                  Rating = RatingType.Love
                              };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RateProvider>().Episode(Constants.ApiKey, episode);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Rating.Should().Be(RatingType.Love);
            result.Facebook.Should().BeTrue();
            result.Type.Should().Be(TraktType.Episode);
        }

        [Test]
        public void RateEpsiode_unrate_should_return_RateResult_on_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 213221,\"title\": \"Portlandia\",\"year\": 2011,\"season\": 1,\"episode\": 1,\"rating\": \"unrate\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"rated Portlandia 1x01\",\"type\":\"episode\",\"rating\":\"unrate\",\"ratings\":{\"percentage\":100,\"votes\":2,\"loved\":2,\"hated\":0},\"facebook\":true,\"twitter\":true,\"tumblr\":false}";

            var episode = new RateEpisode
            {
                Username = "username",
                Password = "sha1hash",
                TvdbId = 213221,
                Title = "Portlandia",
                Year = 2011,
                Season = 1,
                Episode = 1,
                Rating = RatingType.Unrate
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RateProvider>().Episode(Constants.ApiKey, episode);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Rating.Should().Be(RatingType.Unrate);
            result.Facebook.Should().BeTrue();
            result.Type.Should().Be(TraktType.Episode);
        }

        [Test]
        public void RateMovie_should_return_RateResult_on_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"imdb_id\": \"tt0082971\",\"title\": \"Indiana Jones and the Raiders of the Lost Ark\",\"year\": 1981,\"rating\": \"hate\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"rated Indiana Jones and the Raiders of the Lost Ark (1981)\",\"type\":\"movie\",\"rating\":\"hate\",\"ratings\":{\"percentage\":100,\"votes\":15,\"loved\":15,\"hated\":0},\"facebook\":true,\"twitter\":true,\"tumblr\":false}";

            var movie = new RateMovie
            {
                Username = "username",
                Password = "sha1hash",
                ImdbId = "tt0082971",
                Title = "Indiana Jones and the Raiders of the Lost Ark",
                Year = 1981,
                Rating = RatingType.Hate
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RateProvider>().Movie(Constants.ApiKey, movie);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Rating.Should().Be(RatingType.Hate);
            result.Facebook.Should().BeTrue();
            result.Type.Should().Be(TraktType.Movie);
        }

        [Test]
        public void RateMovie_unrate_should_return_RateResult_on_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"imdb_id\": \"tt0082971\",\"title\": \"Indiana Jones and the Raiders of the Lost Ark\",\"year\": 1981,\"rating\": \"unrate\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"rated Indiana Jones and the Raiders of the Lost Ark (1981)\",\"type\":\"movie\",\"rating\":\"unrate\",\"ratings\":{\"percentage\":100,\"votes\":15,\"loved\":15,\"hated\":0},\"facebook\":true,\"twitter\":true,\"tumblr\":false}";

            var movie = new RateMovie()
            {
                Username = "username",
                Password = "sha1hash",
                ImdbId = "tt0082971",
                Title = "Indiana Jones and the Raiders of the Lost Ark",
                Year = 1981,
                Rating = RatingType.Unrate
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RateProvider>().Movie(Constants.ApiKey, movie);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Rating.Should().Be(RatingType.Unrate);
            result.Facebook.Should().BeTrue();
            result.Type.Should().Be(TraktType.Movie);
        }

        [Test]
        public void RateShow_should_return_RateResult_on_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 213221,\"title\": \"Portlandia\",\"year\": 2011,\"rating\": \"love\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"rated Portlandia 1x01\",\"type\":\"episode\",\"rating\":\"love\",\"ratings\":{\"percentage\":100,\"votes\":2,\"loved\":2,\"hated\":0},\"facebook\":true,\"twitter\":true,\"tumblr\":false}";

            var show = new RateShow
            {
                Username = "username",
                Password = "sha1hash",
                TvdbId = 213221,
                Title = "Portlandia",
                Year = 2011,
                Rating = RatingType.Love
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RateProvider>().Show(Constants.ApiKey, show);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Rating.Should().Be(RatingType.Love);
            result.Facebook.Should().BeTrue();
            result.Type.Should().Be(TraktType.Episode);
        }

        [Test]
        public void RateShow_unrate_should_return_RateResult_on_success()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 213221,\"title\": \"Portlandia\",\"year\": 2011,\"rating\": \"unrate\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"rated Portlandia 1x01\",\"type\":\"episode\",\"rating\":\"unrate\",\"ratings\":{\"percentage\":100,\"votes\":2,\"loved\":2,\"hated\":0},\"facebook\":true,\"twitter\":true,\"tumblr\":false}";

            var show = new RateShow
            {
                Username = "username",
                Password = "sha1hash",
                TvdbId = 213221,
                Title = "Portlandia",
                Year = 2011,
                Rating = RatingType.Unrate
            };

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RateProvider>().Show(Constants.ApiKey, show);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Rating.Should().Be(RatingType.Unrate);
            result.Facebook.Should().BeTrue();
            result.Type.Should().Be(TraktType.Episode);
        }
    }
}
