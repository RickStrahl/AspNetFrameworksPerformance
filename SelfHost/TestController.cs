using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        [Route("test/Person")]
        [Route("test/HelloWorldJson")]        
        public Person GetPerson()
        {
            return new Person();
        }


    }
}