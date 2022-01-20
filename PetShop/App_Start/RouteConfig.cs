using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.MapRoute(
               name: "Details",
               url: "Pet-{id}.html",
               defaults: new { controller = "Pet", action = "Details" }
               );
           

            routes.MapRoute(
                name: "PetList",
                url: "Species/{Name}",
                defaults: new { controller = "Pet", action = "ListPet" }
                );
            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
