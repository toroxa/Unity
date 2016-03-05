using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LLV
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //name: "ApiRouteAcessoMenu",
            //routeTemplate: "api/acesso-listar-menus",
            //defaults: new { controller = "ApiAcesso", Action = "GetMenus" }
            //);

            //config.Routes.MapHttpRoute(
            //name: "ApiRouteParametroListar",
            //routeTemplate: "api/parametro-listar",
            //defaults: new { controller = "ApiParametro", Action = "GetParametros" }
            //);
        }
    }
}
