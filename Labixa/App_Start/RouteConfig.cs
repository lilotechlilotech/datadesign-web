using Labixa.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Labixa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("culture", "language/{slug}", new { controller = "Home", action = "SetCulture", slug = UrlParameter.Optional });
            routes.MapRoute("danhsachsanpham", "san-pham/{slug}", new { controller = "ProductHome", action = "Index", slug = UrlParameter.Optional });
            routes.MapRoute("cart", "gio-hang", new { controller = "Cart", action = "Index", slug = UrlParameter.Optional });
            routes.MapRoute("lienhe", "lien-he", new { controller = "Home", action = "about_us", slug = UrlParameter.Optional });
            routes.MapRoute("checkout", "thanh-toan", new { controller = "Cart", action = "checkout", slug = UrlParameter.Optional });
            routes.MapRoute("detailtintuc", "tin-tuc/{slug}", new { controller = "BlogNews", action = "Detail", slug = UrlParameter.Optional });
            routes.MapRoute("chitietsanpham", "san-pham-chi-tiet/{slug}", new { controller = "ProductHome", action = "Detail", slug = UrlParameter.Optional });
            routes.MapRoute("danhsachtintuc", "danh-sach-tin-tuc", new { controller = "BlogNews", action = "Index", slug = UrlParameter.Optional });
            routes.MapRoute("onsale", "khuyen-mai", new { controller = "Onsale", action = "Index", slug = UrlParameter.Optional });
            routes.MapRoute("chinhsachmuahang", "chinh-sach-mua-hang", new { controller = "Home", action = "PolicyBuy", slug = UrlParameter.Optional });
            routes.MapRoute("chinhsachdoitra", "chinh-sach-doi-tra", new { controller = "Home", action = "PolicyReturn", slug = UrlParameter.Optional });
            routes.MapRoute("bangsize", "bang-size", new { controller = "Home", action = "SizeTable", slug = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }


    }
}
