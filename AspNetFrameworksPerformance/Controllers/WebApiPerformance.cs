using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;

namespace AspNetFrameworksPerformance.Controllers
{
    public class WebApiPerformanceController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage HelloWorldCode()
        {
            return new HttpResponseMessage() 
            { Content = new StringContent("Hello World. Time is: " + DateTime.Now.ToString(), Encoding.UTF8, "text/plain") };
        }

        [HttpGet]
        public Person HelloWorldJson()
        {
            return new Person();
        }

        [HttpGet]
        public HttpResponseMessage HelloWorldJson2()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ObjectContent<Person>(new Person(),
                            GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            return response;

            //var response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StringContent(JsonConvert.SerializeObject(new Person()),Encoding.UTF8,"application/json");
            //return response;
        }

        [HttpGet]
        public HttpResponseMessage HelloWorldXml()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ObjectContent<Person>(new Person(), 
                    GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            return response;
        }
   }
}

