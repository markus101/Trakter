using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMoq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Trakter.Models.User;
using Trakter.Providers;
using Trakter.Tests.Framework;

namespace Trakter.Tests.Providers
{
    [TestFixture]
    public class SearchProviderTests
    {
        [Test]
        public void Episodes_should_return_list_of_EpisodeSearchResult()
        {
            //Setup
            var searchTerm = "warfare";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.SearchEpisodes, Constants.ApiKey, searchTerm);

            var jsonResult = File.ReadAllText(@".\Files\Search_Episodes.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<SearchProvider>().Episodes(Constants.ApiKey, searchTerm);

            //Assert
            result.Should().HaveCount(1);
            result.First().Show.Title.Should().Be("Community");
        }

        [Test]
        public void Movies_should_return_list_of_TraktMovie()
        {
            //Setup
            var searchTerm = "batman";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.SearchMovies, Constants.ApiKey, searchTerm);

            var jsonResult = File.ReadAllText(@".\Files\Search_Movies.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<SearchProvider>().Movies(Constants.ApiKey, searchTerm);

            //Assert
            result.Should().HaveCount(1);
            result.First().Title.Should().Be("Batman");
            result.First().Released.Should().HaveYear(1989);
            result.First().Released.Should().HaveMonth(6);
            result.First().Released.Should().HaveDay(23);
        }

        [Test]
        public void People_should_return_list_of_PeopleSearchResult()
        {
            //Setup
            var searchTerm = "christian bale";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.SearchPeople, Constants.ApiKey, "christian+bale");

            var jsonResult = File.ReadAllText(@".\Files\Search_People.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<SearchProvider>().People(Constants.ApiKey, searchTerm);

            //Assert
            result.Should().HaveCount(1);
            result.First().Birthday.Should().Be(new DateTime(1974, 1, 30));
        }

        [Test]
        public void Shows_should_return_list_of_TraktShow()
        {
            //Setup
            var searchTerm = "big bang theory";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.SearchShows, Constants.ApiKey, "big+bang+theory");

            var jsonResult = File.ReadAllText(@".\Files\Search_Shows.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<SearchProvider>().Shows(Constants.ApiKey, searchTerm);

            //Assert
            result.Should().HaveCount(1);
            result.First().Network.Should().Be("CBS");
            result.First().Certification.Should().Be("TV-PG");
        }

        [Test]
        public void Users_should_return_list_of_TraktUser()
        {
            //Setup
            var searchTerm = "justin";
            var expectedUrl = String.Format("{0}{1}/{2}", Url.SearchUsers, Constants.ApiKey, "justin");

            var jsonResult = File.ReadAllText(@".\Files\Search_Users.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(expectedUrl)).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<SearchProvider>().Users(Constants.ApiKey, searchTerm);

            //Assert
            result.Should().HaveCount(1);
            result.First().Age.Should().Be(29);
            result.First().Gender.Should().Be(GenderType.Male);
        }
    }
}
