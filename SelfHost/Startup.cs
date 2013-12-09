using System;
using System.Collections.Generic;
using Microsoft.Owin;
using System.Web.Http;
using Owin;

[assembly: OwinStartup(typeof(SelfHost.Startup))]

namespace SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {        
            //app.UseErrorPage();
            //app.UseWelcomePage();

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            app.UseWebApi(config);            

            app.Run(async (context) =>  // IOWinContext
            {
                context.Response.StatusCode = 200; 
                context.Response.ContentType = "text/html";

                
                string header = "<html><body><h1>Selfhost Vars</h1>";
                await context.Response.WriteAsync(header);

                foreach (KeyValuePair<string, object> keyvalue in context.Environment)
                {
                    if (keyvalue.Value == null)
                        continue;

                    string t = keyvalue.Key + ":  " + keyvalue.Value.ToString() + "<hr />\r\n";

                    await context.Response.WriteAsync(t);
                    //await Task.Delay(1000);  // no output buffering - text just goes
                }

                await context.Response.WriteAsync("</body></html>");
            });
        }
    }
}
