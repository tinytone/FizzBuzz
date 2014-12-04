using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Company.Fizzbuzz.Web.Host
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: string.Empty,
                defaults: new { controller = "Home", action = "List", totalCount = "0", page = 1 }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
