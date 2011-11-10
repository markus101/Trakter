using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Trakter.Models;
using Trakter.Models.Lists;
using Trakter.Providers;
using Trakter.Tests.Framework;

namespace Trakter.Tests.Providers
{
    [TestFixture]
    public class ListProviderTests
    {
        [Test]
        public void AddList_should_return_success_when_list_is_added()
        {
            //Setup
            const string name = "Top 10 of 2011";
            const ListPrivacyType privacy = ListPrivacyType.Public;
            const string description = "These movies and shows really defined 2011 for me.";

            var expectedJson = @"{""username"": ""username"",""password"": ""sha1hash"",""name"": ""Top 10 of 2011"",""description"": ""These movies and shows really defined 2011 for me."",""privacy"": ""public""}";

            var jsonResult = "{\"status\":\"success\",\"message\":\"list added\",\"name\":\"Top 10 of 2011\",\"slug\":\"top-10-of-2011\",\"privacy\":\"public\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ListProvider>().AddList(Constants.ApiKey, "username", "sha1hash", name, privacy, description);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("list added");
            result.Name.Should().Be(name);
            result.Slug.Should().Be(name.Replace(' ', '-').ToLowerInvariant());
            result.Privacy.Should().Be(privacy);
        }

        [Test]
        public void UpdateList_should_return_success_when_list_is_updated()
        {
            //Setup
            const string slug = "top-10-of-2011";
            const string name = "Top 20 of 2011";
            const ListPrivacyType privacy = ListPrivacyType.Friends;
            const string description = "My New Description";

            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"slug\": \"top-10-of-2011\",\"name\": \"Top 20 of 2011\",\"privacy\": \"friends\"}";

            var jsonResult = "{\"status\": \"success\",\"message\": \"list updated\",\"name\": \"Top 20 of 2011\",\"slug\": \"top-20-of-2011\",\"privacy\": \"friends\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ListProvider>().UpdateList(Constants.ApiKey, "username", "sha1hash", slug, name, privacy);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("list updated");
            result.Name.Should().Be(name);
            result.Should().NotBe(slug);
            result.Slug.Should().Be(name.Replace(' ', '-').ToLowerInvariant());
            result.Privacy.Should().Be(privacy);
        }

        [Test]
        public void DeleteList_should_return_success_when_list_is_deleted()
        {
            //Setup
            const string slug = "top-10-of-2011";

            var expectedJson = "{\"username\": \"username\",\"password\": \"sha1hash\",\"slug\": \"top-10-of-2011\"}";

            var jsonResult = "{\"status\": \"success\",\"message\": \"list and items deleted\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ListProvider>().DeleteList(Constants.ApiKey, "username", "sha1hash", slug);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().Be("list and items deleted");
            Console.WriteLine(result);
        }

        [Test]
        public void AddListItems_should_return_success_when_list_items_are_added()
        {
            //Setup
            const string slug = "new-test-list";

            var items = new List<dynamic>();
            items.Add(new { Type = "movie", Tmdb_id = 161, Title = "Ocean's 11", Year = 2001 });
            items.Add(new { Type = "show", Title = "30 Rock", Tvdb_Id = 79488 });

            var expectedJson = "{\"username\":\"username\",\"password\":\"sha1hash\",\"slug\":\"new-test-list\",\"items\":[{\"type\":\"movie\",\"tmdb_id\":161,\"title\":\"Ocean's 11\",\"year\":2001},{\"type\":\"show\",\"title\":\"30 Rock\",\"tvdb_id\":79488}]}";

            var jsonResult = "{\"status\": \"success\",\"inserted\": 2,\"already_exist\": 0,\"skipped\": 0,\"skipped_array\": []}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ListProvider>().AddListItems(Constants.ApiKey, "username", "sha1hash", slug, items);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Inserted.Should().Be(items.Count);
            result.Skipped.Should().Be(0);
            result.Already_Exist.Should().Be(0);
        }

        [Test]
        public void DeleteListItems_should_return_success_when_list_items_are_deleted()
        {
            //Setup
            const string slug = "new-test-list";

            var items = new List<dynamic>();
            items.Add(new { Type = "movie", Tmdb_id = 161, Title = "Ocean's 11", Year = 2001 });
            items.Add(new { Type = "show", Title = "30 Rock", Tvdb_Id = 79488 });

            var expectedJson = "{\"username\":\"username\",\"password\":\"sha1hash\",\"slug\":\"new-test-list\",\"items\":[{\"type\":\"movie\",\"tmdb_id\":161,\"title\":\"Ocean's 11\",\"year\":2001},{\"type\":\"show\",\"title\":\"30 Rock\",\"tvdb_id\":79488}]}";

            var jsonResult = "{\"status\": \"success\",\"message\": \"2 items deleted\"}";

            var mocker = new AutoMoqer();
            mocker.GetMock<HttpProvider>().Setup(s => s.DownloadString(It.IsAny<String>(), It.Is<string>(e => e.Replace(" ", "").Replace("\r\n", "").Replace("\t", "") == expectedJson.Replace(" ", "")))).Returns(jsonResult);

            //Act
            var result = mocker.Resolve<ListProvider>().DeleteListItems(Constants.ApiKey, "username", "sha1hash", slug, items);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
            result.Message.Should().NotBeNullOrEmpty();
            result.Message.Should().StartWith(items.Count.ToString());
        }
    }
}
