using System.Diagnostics;
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
            string output = "Hello cruel World. " + DateTime.Now.ToString();


            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(output, Encoding.UTF8, "text/plain") };
        }

        [HttpGet]
        public string WorkingSet()
        {
            return "Asp.NET - Working set is: " + Process.GetCurrentProcess().WorkingSet.ToString("n0") + " bytes";
        }


        [HttpGet]
        public Person HelloWorldJsonTypedResult()
        {
            return new Person();
        }

        [HttpGet]
        public HttpResponseMessage HelloWorldJsonCreateResponse()
        {
            var response = Request.CreateResponse<Person>(HttpStatusCode.OK, new Person());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage HelloWorldJsonManualResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ObjectContent<Person>(new Person(),
                            GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            return response;
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

