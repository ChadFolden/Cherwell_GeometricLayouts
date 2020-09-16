using System.Net.Http.Formatting;
using System.Web.Http;

namespace Cherwell_GeometryWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Register);

            //Force JSON responses on all requests
            //GlobalConfiguration.Configuration.Formatters.Clear();
            //GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
        }

        public void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
