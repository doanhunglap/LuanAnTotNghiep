using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyPhongKham
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
             name: "Staff",
             url: "doi-ngu",
             defaults: new { controller = "Staff", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] {"QuanLyPhongKham.Controllers"}
            );

            routes.MapRoute(
             name: "Staff1",
             url: "doi-ngu/{link}",
             defaults: new { controller = "Staff", action = "Detail", id = UrlParameter.Optional },
             namespaces: new[] { "QuanLyPhongKham.Controllers" }
            );

            routes.MapRoute(
             name: "Contact",
             url: "lien-he",
             defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "QuanLyPhongKham.Controllers" }
            );

            routes.MapRoute(
             name: "About",
             url: "gioi-thieu",
             defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "QuanLyPhongKham.Controllers" }
            );

            routes.MapRoute(
             name: "Blog",
             url: "tin-tuc",
             defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "QuanLyPhongKham.Controllers" }
            );

            routes.MapRoute(
             name: "Blog-link",
             url: "tin-tuc/{Link}",
             defaults: new { controller = "Blog", action = "DetailBlog", id = UrlParameter.Optional },
             namespaces: new[] { "QuanLyPhongKham.Controllers" }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new [] {"QuanLyPhongKham.Controllers"}
            );

            
        }
    }
}
