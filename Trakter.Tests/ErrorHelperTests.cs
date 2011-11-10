using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using Trakter.Models;

namespace Trakter.Tests
{
    [TestFixture]
    public class ErrorHelperTests
    {
        [Test]
        public void ErrorResonse_should_return_true_for_an_invalid_api_key_response()
        {
            //Setup
            var jsonResponse = "{ \"status\": \"failure\", \"error\": \"invalid API key\" }";
            
            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Failure);
        }

        [Test]
        public void ErrorResonse_should_return_true_for_an_invalid_development_api_key_response()
        {
            //Setup
            var jsonResponse = "{ \"status\": \"failure\", \"error\": \"invalid development API key\" }";

            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Failure);
        }

        [Test]
        public void ErrorResonse_should_return_true_for_an_invalid_development_api_key_permissions_response()
        {
            //Setup
            var jsonResponse = "{ \"status\": \"failure\", \"error\": \"invalid development API permission (scrobble)\" }";

            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Failure);
        }

        [Test]
        public void ErrorResonse_should_return_true_for_an_invalid_username_or_password()
        {
            //Setup
            var jsonResponse = "{ \"status\": \"failure\", \"error\": \"failed authentication\" }";

            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Failure);
        }

        [Test]
        public void ErrorResonse_should_return_true_for_server_is_over_capacity_resonse()
        {
            //Setup
            var jsonResponse = "{ \"status\": \"failure\", \"error\": \"server is over capacity\" }";

            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Failure);
        }

        [Test]
        public void ErrorResonse_should_return_false_for_non_error_response()
        {
            //Setup
            var jsonResponse = "[{\"name\":\"Action\",\"slug\":\"action\"},{\"name\":\"Adventure\",\"slug\":\"adventure\"},{\"name\":\"Animation\",\"slug\":\"animation\"},{\"name\":\"Children\",\"slug\":\"children\"},{\"name\":\"Comedy\",\"slug\":\"comedy\"},{\"name\":\"Documentary\",\"slug\":\"documentary\"},{\"name\":\"Drama\",\"slug\":\"drama\"},{\"name\":\"Fantasy\",\"slug\":\"fantasy\"},{\"name\":\"Game Show\",\"slug\":\"game-show\"},{\"name\":\"Home and Garden\",\"slug\":\"home-and-garden\"},{\"name\":\"Mini Series\",\"slug\":\"mini-series\"},{\"name\":\"News\",\"slug\":\"news\"},{\"name\":\"Reality\",\"slug\":\"reality\"},{\"name\":\"Science Fiction\",\"slug\":\"science-fiction\"},{\"name\":\"Soap\",\"slug\":\"soap\"},{\"name\":\"Special Interest\",\"slug\":\"special-interest\"},{\"name\":\"Sport\",\"slug\":\"sport\"},{\"name\":\"Talk Show\",\"slug\":\"talk-show\"},{\"name\":\"Western\",\"slug\":\"western\"}]";

            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
        }

        [Test]
        public void ErrorResonse_should_return_false_for_empty_response()
        {
            //Setup
            var jsonResponse = "[]";

            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
        }

        [Test]
        public void ErrorResonse_should_return_false_for_successful_response()
        {
            //Setup
            var jsonResponse = "{ \"status\": \"success\", \"message\": \"not an error!\" }";

            //Act
            var result = ErrorHelper.ErrorResponse(jsonResponse);

            //Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResultStatusType.Success);
        }
    }
}
