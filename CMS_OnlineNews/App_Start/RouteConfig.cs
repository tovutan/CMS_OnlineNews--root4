using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS_OnlineNews
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           

            routes.MapRoute(
          "LoadPostCategory",
          "{page}/{catURL}/{hotNum}",
          new { controller = "Home", action = "LoadPostCategory", queryValues = UrlParameter.Optional },
          new[] { "CMS_OnlineNews.Controllers" }
          );

            routes.MapRoute(
            "Ajax",
            "Ajax/{controller}/{action}",
            new { controller="Home",action= "ListPostHome", queryValues=UrlParameter.Optional},
            new[] { "CMS_OnlineNews.Controllers"}
                );

            routes.MapRoute(
             "ListPostCategory",
             "{catURL}",
             new { controller = "Home", action = "ListPostCategory", queryValues = UrlParameter.Optional },
             new[] { "CMS_OnlineNews.Controllers" }
           );

            routes.MapRoute(
            "PostDetail",
            "{catURL}/{postUrl}",
             new { controller = "Home", action = "Detail", queryValues = UrlParameter.Optional },
             new[] { "CMS_OnlineNews.Controllers" }
            );

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "CMS_OnlineNews.Controllers" }
                );

        }
    }
}
