using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _036_MoviesMvcWissen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");// istediğimin route ı erişilemez hale getirme yolu

            //routes.Add( // Add li yolu
            //      "GetReviews", new Route("getreviews", new RouteValueDictionary( new {controller = "Reviews", action = "Index"}), new MvcRouteHandler())
            //    );

            routes.MapRoute(
                name: "GetReviews",
                url: "getreviews",
                defaults: new { controller = "Reviews", action = "Index", id = UrlParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint("POST", "GET") }
                );

            routes.MapRoute(
             name: "CreateReview",
             url: "createreview",
             defaults: new { controller = "Reviews", action = "Create" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new string[]
                { "_036_MoviesMvcWissen.Controllers" }
            );

            //routes.MapRoute(
            //    "Profile",
            //    //"{userName}",// kullanıcı adı about veya contact şeklinde girildiğinde URL yönlendirmede sorun çıkacaktır
            //    "u/{userName}",
            //    new { controller = "Account", action = "Profile" }
            //    );

          

        }
    }
}
