using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AppEstimator.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Guest",
            url: "Guest/{action}/{id}",
            defaults: new { controller = "Guest", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Estimate",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Manage", action = "Index", id = AppEstimator.Mvc.Controllers.ManageController.ManageMessageId.Error });
        }
    }
}
