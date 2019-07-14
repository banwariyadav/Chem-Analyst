using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChemAnalyst
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("NewsDetails", new SeoFriendlyRoute("NewsAndDeals/NewsDetails/{id}",
           new RouteValueDictionary(new { controller = "NewsAndDeals", action = "NewsDetails" }),
           new MvcRouteHandler()));

            routes.Add("DealsDetails", new SeoFriendlyRoute("NewsAndDeals/DealsDetails/{id}",
         new RouteValueDictionary(new { controller = "NewsAndDeals", action = "DealsDetails" }),
         new MvcRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ChemAnalyst", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
