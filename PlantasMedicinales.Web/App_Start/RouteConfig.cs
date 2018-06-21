using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlantasMedicinales.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Catalogo", action = "Index" }
            );


            routes.MapRoute(
                "Defaulxt", // Route name
                "{*catchall}", // URL with parameters
                new { controller = "Catalogo", action = "Index" } // Parameter defaults
            );

        }
    }
}
