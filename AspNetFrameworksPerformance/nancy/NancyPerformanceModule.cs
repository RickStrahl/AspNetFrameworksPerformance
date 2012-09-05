using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace AspNetFrameworksPerformance.Controllers
{
    public class NancyPerformanceModule : NancyModule
    {
        public NancyPerformanceModule()
            : base("/nancy")
        {
            Get["/"] = _ =>
            {
                return "Hello Nancy";
            };

            //Get["/NancyFx/HelloWorldCode"] = _ =>
            Get["/HelloWorldCode"] = _ =>
            {
                return "Hello World. Time is: " + DateTime.Now.ToString();
            };

            Get["/HelloWorldJson"] = _ =>
            {
                return Response.AsJson(new Person());
            };
        }
    }
}