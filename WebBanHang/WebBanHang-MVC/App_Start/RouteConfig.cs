using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHang_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {


          
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "giohang",
               url: "them-gio-hang/{MetaTitle}-{id}",
               defaults: new { controller = "GioHang", action = "ThemVaoGio", id = UrlParameter.Optional }
           );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "suagiohang",
               url: "sua-gio-hang/{MetaTitle}-{id}",
               defaults: new { controller = "GioHang", action = "SuaSoLuong", id = UrlParameter.Optional }
           );


            //cái này mặc định dữ nguyên pải để xuống dưới cùng
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}