using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhoneStoreWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"PhoneStoreWeb.Controllers"}
            );
            routes.MapRoute(
                name: "Category",
                url: "san-pham",
                defaults: new { controller = "Category", action = "getProductbyMeta", id = UrlParameter.Optional },
                namespaces: new[] { "PhoneStoreWeb.Controllers" }
            );
            routes.MapRoute(
                name: "ShoppingCart",
                url: "gio-hang",
                defaults: new { controller = "ShoppingCart", action = "Index", meta = UrlParameter.Optional },
                namespaces: new[] { "PhoneStoreWeb.Controllers" }
            );
        }
    }
}
