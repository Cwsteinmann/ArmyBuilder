// <copyright file="ArmyManagerController.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager.API
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using DotNetNuke.Security;
    using DotNetNuke.Services.Exceptions;
    using DotNetNuke.Web.Api;

    /// <summary>The web API for the module</summary>
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    [SupportedModules("Testing: Army Manager")]
    public class ArmyManagerController : DnnApiController
    {
        /// <summary>Gets the Army Manager</summary>
        /// <param name="getArmyManagerRequest">The request.</param>
        /// <returns>An <see cref="HttpRequestMessage" /> with a <see cref="ArmyManagerViewModel"/> instances, or an error response.</returns>
        [HttpGet]
        public HttpResponseMessage GetArmyManager([FromUri]GetArmyManagerRequest getArmyManagerRequest)
        {
            try
            {
                var response = getArmyManagerRequest.Item1.Equals("Foo", StringComparison.OrdinalIgnoreCase)
                                ? "Bar"
                                : getArmyManagerRequest.Item1;
                return this.Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
                return this.Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new { errorMessage = "There was an unexpected error processing the request", });
            }
        }
    }
}
