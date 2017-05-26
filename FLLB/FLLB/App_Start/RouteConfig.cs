using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FLLB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "unsubscribe",
              url: "u/{id}",
              defaults: new { controller = "Campaign", action = "Unsubscribe"}
          );

            routes.MapRoute(
               name: "campaignclick",
               url: "m/{id}",
               defaults: new { controller = "Campaign", action = "CampaignClick"}
           );

          

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
        }
    }
}
