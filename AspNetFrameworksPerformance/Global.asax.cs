using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetFrameworksPerformance
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //var formatters = GlobalConfiguration.Configuration.Formatters;
            //formatters.Remove(formatters.XmlFormatter);

            // make sure this gets defined before MVC routes
            RouteTable.Routes.MapHttpRoute(
                name: "WebApiPerformanceAction",
                routeTemplate: "api/{action}",
                defaults: new
                {
                    title = RouteParameter.Optional,
                    controller = "WebApiPerformance",
                    action = "HelloWorldCode"
                }
            );

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}