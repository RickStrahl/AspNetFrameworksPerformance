using AspNetFrameworksPerformance.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFrameworksPerformance
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var action = context.Request.QueryString["action"];
            if (action == "json")
                JsonRequest(context);
            else
                TextRequest(context);
        }

        public void TextRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World. Time is: " + DateTime.Now.ToString());
        }

        public void JsonRequest(HttpContext context)
        {
            var json = JsonConvert.SerializeObject(new Person(), Formatting.None);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}