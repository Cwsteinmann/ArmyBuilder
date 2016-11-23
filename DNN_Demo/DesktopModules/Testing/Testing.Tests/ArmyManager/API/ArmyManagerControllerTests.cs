// <copyright file="ArmyManagerControllerTests.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager.Tests.API
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;

    using FakeItEasy;

    using Dnn.ArmyManager.API;

    using Newtonsoft.Json;

    using Xunit;

    public class ArmyManagerControllerTests
    {
        /// <summary>Assert that the response is good and contains "Bar".</summary>
        [Fact]
        public void Assert_contains_bar_in_response()
        {
            var controller = GetArmyManagerController();

            var result = controller.GetArmyManager(new GetArmyManagerRequest("Foo"));
            Assert.Equal(result.StatusCode, HttpStatusCode.OK);

            var returnedMessage = JsonConvert.DeserializeObject<string>(result.Content.ReadAsStringAsync().Result);
            Assert.Equal(returnedMessage, "Bar");
        }

        /// <summary>Asserts that the response is good and contains "FooBar".</summary>
        [Fact]
        public void Assert_contains_foobar_in_response()
        {
            var controller = GetArmyManagerController();

            var result = controller.GetArmyManager(new GetArmyManagerRequest("FooBar"));
            Assert.Equal(result.StatusCode, HttpStatusCode.OK);

            var returnedMessage = JsonConvert.DeserializeObject<string>(result.Content.ReadAsStringAsync().Result);
            Assert.Equal(returnedMessage, "FooBar");
        }

        /// <summary>Assert_bad_request_returns_server_error_and_friendly_error_messages this instance.</summary>
        [Fact]
        public void Assert_bad_request_returns_server_error_and_friendly_error_message()
        {
            var controller = GetArmyManagerController();
            var result = controller.GetArmyManager(null);
            var returnedMessage = result.Content.ReadAsStringAsync().Result;

            Assert.Equal(result.StatusCode, HttpStatusCode.InternalServerError);
            Assert.Equal(returnedMessage, "{\"errorMessage\":\"There was an unexpected error processing the request\"}");
        }

        /// <summary>Gets a controller instance.</summary>
        /// <returns>A new <see cref="ArmyManagerController"/> instance with default context</returns>
        private static ArmyManagerController GetArmyManagerController()
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage { Method = HttpMethod.Post };
            var route = config.Routes.MapHttpRoute("default", "api/controller/action");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "GetArmyManager" } });
            var controller = new ArmyManagerController { ControllerContext = new HttpControllerContext(config, routeData, request), Request = request };

            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            return controller;
        }
   }
}
