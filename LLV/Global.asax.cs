using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using LLV.Controllers;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LLV
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new TokenAuthMessageHandler());
            //GlobalConfiguration.Configuration.Filters.Add(new CustomExceptionFilter());

            //GlobalConfiguration.Configuration.Filters.Add(new System.Web.Http.AuthorizeAttribute());
            //GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());

            ConfigureApiReturnOnlyJson();
            ConfigureNewtonsoftJsonFormatter();

            Util.Config.Configurar();
        }

        private static void ConfigureApiReturnOnlyJson()
        {
            Collection<MediaTypeHeaderValue> mediaTypeHeaderValues = GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes;
            MediaTypeHeaderValue appXmlType = mediaTypeHeaderValues.FirstOrDefault(t => t.MediaType == "application/xml");

            if (null != appXmlType)
            {
                mediaTypeHeaderValues.Remove(appXmlType);
            }
        }

        private static void ConfigureNewtonsoftJsonFormatter()
        {
            MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;
            JsonMediaTypeFormatter jsonFormatter = formatters.JsonFormatter;
            JsonSerializerSettings settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.None;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void Application_Error(object sender, EventArgs e)
        {
            //Exception lastServerException = Server.GetLastError();

            //if (lastServerException is HttpException && lastServerException.Message.Contains("Request.Path"))
            //{
            //    var app404 = (Global)sender;
            //    HttpContext context404 = app404.Context;

            //    context404.Response.StatusCode = 404;
            //    context404.ClearError();

            //    var routeData404 = new RouteData();
            //    routeData404.Values["controller"] = "NotFound";
            //    routeData404.Values["action"] = "Index";

            //    IController controller404 = new NotFoundController();

            //    controller404.Execute(
            //        new RequestContext(
            //            new HttpContextWrapper(context404),
            //            routeData404));

            //    return;
            //}

            //bool gravarErrosNaDBAuditor;
            //if (false == bool.TryParse(Dekra.Util.Config.ObterAppSetting("gravarErrosNaDBAuditor"), out gravarErrosNaDBAuditor) ||
            //    false == gravarErrosNaDBAuditor)
            //{
            //    return;
            //}

            //string method = HttpContext.Current.Request.HttpMethod;
            //Uri url = HttpContext.Current.Request.Url;

            //string message = string.Format(
            //    "WebSITE: Unhandled exception processing {0} for {1}: {2}"
            //  , method
            //  , url
            //  , lastServerException.Message);

            //IList<Log> logs = Log.CreateError(lastServerException, message);

            //var repository = new Repository();

            //foreach (Log log in logs)
            //{
            //    repository.SaveOrUpdate(log);
            //}
        }
    }
}