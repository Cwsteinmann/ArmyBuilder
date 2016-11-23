// <copyright file="ArmyManagerRouter.cs" company="Testing">
// Testing: Army Manager
// Copyright (c) 2016
// </copyright>
namespace Testing.Dnn.ArmyManager.API
{
    using DotNetNuke.Web.Api;

    /// <summary>Defines the routes for the web API</summary>
    public class ArmyManagerRouter : IServiceRouteMapper
    {
        /// <summary>Registers the route for the web service.</summary>
        /// <param name="mapRouteManager">The route manager.</param>
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                "Testing/ArmyManager",
                "default",
                "{controller}/{action}",
                new[] { "Testing.Dnn.ArmyManager.API", });
        }
    }
}
