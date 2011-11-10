using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMoq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Trakter.Providers;
using Trakter.Tests.Framework;

namespace Trakter.Tests.Providers
{
    [TestFixture]
    public class GenreProviderTests
    {
        [Test]
        public void GetMovieGenres_should_return_List_of_Genre()
        {
            //Setup
            var date = new DateTime(2011, 11, 02);

            var jsonResult = File.ReadAllText(@".\Files\Genres.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>())).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<GenreProvider>().GetMovieGenres(Constants.ApiKey);

            //Assert
            result.Should().NotBeEmpty();
        }

        [Test]
        public void GetShowGenres_should_return_List_of_Genre()
        {
            //Setup
            var date = new DateTime(2011, 11, 02);

            var jsonResult = File.ReadAllText(@".\Files\Genres.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>())).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<GenreProvider>().GetShowGenres(Constants.ApiKey);

            //Assert
            result.Should().NotBeEmpty();
        }
    }
}
