using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventsCalendar.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Events", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "GetNewDateInYear",
                url: "{controller}/{action}/{month}/{day}/{year}",
                defaults: new { controller = "Events", action = "GetDay" }
            );

            routes.MapRoute(
                name: "GetNewYear",
                url: "{controller}/{action}/{month}/{year}",
                defaults: new { controller = "Events", action = "GetYear" }
            );
        }
    }
}
