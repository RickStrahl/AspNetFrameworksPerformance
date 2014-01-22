using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HeliosSample
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("test/HelloWorld/{name?}")]
        public string HelloWorld(string name = null)
        {            
            return "Hello cruel World, " + name + ". " + DateTime.Now;            
        }

        [HttpGet]
        [Route("test/WorkingSet")]
        public string WorkingSet()
        {
            return "Helios - Working set is: " + Process.GetCurrentProcess().WorkingSet.ToString("n0") + " bytes";
        }
        [HttpGet]
        [Route("test/PersonResponse")]
        public HttpResponseMessage HelloWorldJsonCreateResponse()
        {
            var response = Request.CreateResponse<Person>(HttpStatusCode.OK, new Person());
            return response;
        }

        [HttpGet]
        [Route("test/Person")]
        public Person GetPerson()
        {
            return new Person();
        }


    }
}