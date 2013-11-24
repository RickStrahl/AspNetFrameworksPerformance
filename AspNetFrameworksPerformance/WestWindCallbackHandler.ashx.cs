using AspNetFrameworksPerformance.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Westwind.Web;

namespace AspNetFrameworksPerformance
{
    /// <summary>
    /// Summary description for WestWindCallbackHandler
    /// </summary>
    public class WestWindCallbackHandler : CallbackHandler
    {
        [CallbackMethod]
        public string HelloWorld()
        {
            return "Hello World " + DateTime.Now.ToString();
        }

        [CallbackMethod]
        public Person HelloWorldJson()
        {
            return new Person();
        }
       
    }
}