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
    public class CalendarProviderTests
    {
        [Test]
        public void GetPremieres_should_return_list_of_days()
        {
            //Setup
            var date = new DateTime(2011, 11, 02);

            var jsonResult = File.ReadAllText(@".\Files\Calendar_Premieres.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>())).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<CalendarProvider>().GetPremieres(Constants.ApiKey, date);

            //Assert
            result.Should().HaveCount(1);
            Console.WriteLine(result);
        }

        [Test]
        public void GetPremieres_should_return_empty_result_when_no_data_is_returned_from_server()
        {
            //Setup
            var date = new DateTime(2020, 01, 01);

            var jsonResult = "[ ]";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>())).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<CalendarProvider>().GetPremieres(Constants.ApiKey, date);

            //Assert
            result.Should().BeEmpty();
            Console.WriteLine(result);
        }

        [Test]
        public void GetShows_should_return_list_of_days()
        {
            //Setup
            var date = new DateTime(2011, 11, 02);

            var jsonResult = File.ReadAllText(@".\Files\Calendar_Shows.txt");

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>())).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<CalendarProvider>().GetShows(Constants.ApiKey, date);

            //Assert
            result.Should().HaveCount(1);
            Console.WriteLine(result);
        }

        [Test]
        public void GetShows_should_return_empty_result_when_no_data_is_returned_from_server()
        {
            //Setup
            var date = new DateTime(2020, 01, 01);

            var jsonResult = "[ ]";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>())).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<CalendarProvider>().GetShows(Constants.ApiKey, date);

            //Assert
            result.Should().BeEmpty();
            Console.WriteLine(result);
        }
    }
}
