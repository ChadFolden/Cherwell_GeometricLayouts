using System.Web.Http;

namespace Cherwell_GeometryWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            //Config routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{KeyVal}",
                defaults: new { KeyVal = RouteParameter.Optional }
            );
        }
    }
}
