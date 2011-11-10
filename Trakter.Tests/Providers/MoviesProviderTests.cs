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
    public class MoviesProviderTests
    {
        [Test]
        public void Trending_should_return_currently_trending_movies()
        {
            //Setup
            var jsonResult = File.ReadAllText(@".\Files\Movies_Trending.txt");
            var expectedUrl = String.Format("{0}{1}", Url.MoviesTrending, Constants.ApiKey);

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MoviesProvider>().Trending(Constants.ApiKey);

            //Assert
            result.Should().HaveCount(2);
        }

        [Test]
        public void Trending_should_return_currently_trending_movies_with_user_specific_details()
        {
            //Setup
            var jsonResult = File.ReadAllText(@".\Files\Movies_Trending_WithUserDetails.txt");
            var expectedUrl = String.Format("{0}{1}", Url.MoviesTrending, Constants.ApiKey);
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl, It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<MoviesProvider>().Trending(Constants.ApiKey, "username", "sha1hash");

            //Assert
            result.Should().HaveCount(2);
            result.First().Watched.Should().BeTrue();
            result.First().Plays.Should().Be(3);
            result.First().Rating.Should().Be(RatingType.Love);
            result.First().InWatchlist.Should().BeTrue();
            result.First().InCollection.Should().BeTrue();
        }
    }
}