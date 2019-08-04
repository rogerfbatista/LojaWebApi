using System.Web.Http;
using Loja.WebApi.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Loja.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            config.EnableCors();

            var formart = config.Formatters;
            formart.Remove(formart.XmlFormatter);
            var json = config.Formatters.JsonFormatter.SerializerSettings;
            json.Formatting = Formatting.Indented;
            json.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formart.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
             formart.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
     


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
