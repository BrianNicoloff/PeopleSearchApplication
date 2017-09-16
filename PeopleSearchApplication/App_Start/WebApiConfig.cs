using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PeopleSearchApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
//            XmlConfigurator.Configure();
//            var builder = new ContainerBuilder();
//
//            Dependencies.Resolve(builder);
//            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
//            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            FormatJson(config);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
                );
        }

        private static void FormatJson(HttpConfiguration config)
        {
            var jsonMediaTypeFormatter = config.Formatters.JsonFormatter;
            jsonMediaTypeFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonMediaTypeFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.Formatters.Clear();
            config.Formatters.Add(jsonMediaTypeFormatter);
        }
    }
}
