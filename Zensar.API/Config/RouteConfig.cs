using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Zensar.API.Config
{
    public class ApiRouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            var routes = config.Routes;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
