using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.UI.Web.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*1.Mapa de ruta estática*/
            routes.MapRoute(
                name:"rutaEstaticaCatalogo",
                url: "Catalogo",
                defaults: new
                {
                    Controller = "Producto",
                    Action = "Index2"
                }
            );

            /*2.Mapa de ruta SEO*/
            routes.MapRoute(
                name: "rutaEstatica",
                url: "Catalogo/{id}/{name}",
                defaults: new
                {
                    Controller = "Producto",
                    Action = "Edit"
                }
            );

            /*Mapa de rutas por defecto debe ir al final*/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
