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
using Trakter.Models.Genres;
using Trakter.Models.Shout;
using Trakter.Providers;
using Trakter.Tests.Framework;

namespace Trakter.Tests.Providers
{
    [TestFixture]
    public class ShoutProviderTests
    {
        [Test]
        public void SendShout_should_return_a_success_response_for_an_episode_shout()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShoutEpisode, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 213221,\"title\": \"Portlandia\",\"year\": 2011,\"season\": 1,\"episode\": 1,\"shout\": \"The opening musical number is just superb!\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"shout added to Portlandia 1x01\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            var shout = new ShoutEpisode
                            {
                                Username = "username",
                                Password = "sha1hash",
                                TvdbId = 213221,
                                Title = "Portlandia",
                                Year = 2011,
                                Season = 1,
                                Episode = 1,
                                Shout = "The opening musical number is just superb!"
                            };

            //Act
            var result = mocker.Resolve<ShoutProvider>().SendShout(Constants.ApiKey, shout);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("shout added to Portlandia 1x01");
        }

        [Test]
        public void SendShout_should_return_a_success_response_for_a_movie_shout()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShoutMovie, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"imdb_id\": \"tt0082971\",\"title\": \"Indiana Jones and the Raiders of the Lost Ark\",\"year\": 1981,\"shout\": \"I grew up with this movie and even today it is EPIC.\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"shout added to Indiana Jones and the Raiders of the Lost Ark (1981)\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            var shout = new ShoutMovie
            {
                Username = "username",
                Password = "sha1hash",
                ImdbId = "tt0082971",
                Title = "Indiana Jones and the Raiders of the Lost Ark",
                Year = 1981,
                Shout = "I grew up with this movie and even today it is EPIC."
            };

            //Act
            var result = mocker.Resolve<ShoutProvider>().SendShout(Constants.ApiKey, shout);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("shout added to Indiana Jones and the Raiders of the Lost Ark (1981)");
        }

        [Test]
        public void SendShout_should_return_a_success_response_for_a_show_shout()
        {
            //Setup
            var expectedUrl = String.Format("{0}{1}", Url.ShoutShow, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 213221,\"title\": \"Portlandia\",\"year\": 2011,\"shout\": \"First episode was pretty good, but it went downhill fast.\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"shout added to Portlandia\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            var shout = new ShoutShow
            {
                Username = "username",
                Password = "sha1hash",
                TvdbId = 213221,
                Title = "Portlandia",
                Year = 2011,
                Shout = "First episode was pretty good, but it went downhill fast."
            };

            //Act
            var result = mocker.Resolve<ShoutProvider>().SendShout(Constants.ApiKey, shout);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("shout added to Portlandia");
        }
    }
}
