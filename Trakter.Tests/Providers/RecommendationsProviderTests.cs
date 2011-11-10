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
    public class RecommendationsProviderTests
    {
        [Test]
        public void Movies_should_return_list_of_movies()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"genre\": \"action\"}";
            var jsonResult = "[{\"title\":\"The Expendables\",\"year\":2010,\"released\":1283410800,\"url\":\"http://trakt.tv/movie/the-expendables-2010\",\"runtime\":103,\"tagline\":\"Choose Your Weapon.\",\"overview\":\"Barney Ross (Stallone) leads a band of highly skilled mercenaries including knife enthusiast Lee Christmas (Statham), a martial arts expert, heavy weapons specialist, demolitionist, and a loose-cannon sniper. When the group is commissioned by the mysterious Mr. Church to assassinate the dictator of a small South American island, Barney and Lee visit the remote locale to scout out their opposition and discover the true nature of the conflict engulfing the city.\",\"certification\":\"R\",\"imdb_id\":\"tt1320253\",\"tmdb_id\":\"27578\",\"images\":{\"poster\":\"http://vicmackey.trakt.tv/images/posters_movies/304.jpg\",\"fanart\":\"http://vicmackey.trakt.tv/images/fanart_movies/304.jpg\"},\"ratings\":{\"percentage\":69,\"votes\":36,\"loved\":25,\"hated\":11}}]";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RecommendationsProvider>().Movies(Constants.ApiKey, "username", "sha1hash", new Genre{ Name = "Action", Slug = "action" });

            //Assert
            result.Should().HaveCount(1);
            result.First().Year.Should().Be(2010);
            result.First().Runtime.Should().Be(103);
            result.First().TmdbId.Should().Be(27578);
        }

        [Test]
        public void DismissMovie_should_return_success_with_movie()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"imdb_id\": \"tt0435761\"}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"dismissed Toy Story 3 (2010)\",\"movie\":{\"title\":\"Toy Story 3\",\"year\":\"2010\",\"imdb_id\":\"tt0435761\",\"tmdb_id\":\"10193\"}}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RecommendationsProvider>().DismissMovie(Constants.ApiKey, "username", "sha1hash", "tt0435761" );

            //Assert
            result.Should().NotBeNull();
            result.Movie.Title.Should().Be("Toy Story 3");
        }

        [Test]
        public void Shows_should_return_list_of_shows()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"genre\": \"action\"}";
            var jsonResult = "[{\"title\":\"Fringe\",\"year\":2008,\"url\":\"http://trakt.tv/show/fringe\",\"first_aired\":1219734000,\"country\":\"United States\",\"overview\":\"Fringe follows FBI Agent Olivia Dunham, Consultant Peter Bishop and science explorer extraordinaire Doctor Walter Bishop as they search for clues to the series of bizarre and horrific crimes inflicted on the world. The world that we know. \",\"runtime\":60,\"certification\":\"TV-MA\",\"imdb_id\":\"tt1119644\",\"tvdb_id\":\"82066\",\"images\":{\"poster\":\"http://vicmackey.trakt.tv/images/posters/87.jpg\",\"fanart\":\"http://vicmackey.trakt.tv/images/fanart/87.jpg\"},\"ratings\":{\"percentage\":97,\"votes\":195,\"loved\":190,\"hated\":5}}]";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RecommendationsProvider>().Shows(Constants.ApiKey, "username", "sha1hash", new Genre { Name = "Action", Slug = "action" });

            //Assert
            result.Should().HaveCount(1);
            result.First().Runtime.Should().Be(60);
            result.First().TvdbId.Should().Be(82066);
            result.First().FirstAired.Should().HaveYear(2008);
            result.First().FirstAired.Should().HaveMonth(08);
            result.First().FirstAired.Should().HaveDay(26);
        }

        [Test]
        public void DismissShow_should_return_success_with_movie()
        {
            //Setup
            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"tvdb_id\": 80348}";
            var jsonResult = "{\"status\":\"success\",\"message\":\"dismissed Chuck\",\"movie\":{\"title\":\"Chuck\",\"year\":\"2007\",\"imdb_id\":\"tt0934814\",\"tmdb_id\":\"80348\"}}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<RecommendationsProvider>().DismissShow(Constants.ApiKey, "username", "sha1hash", null, 80348);

            //Assert
            result.Should().NotBeNull();
            result.Movie.Title.Should().Be("Chuck");
        }
    }
}
