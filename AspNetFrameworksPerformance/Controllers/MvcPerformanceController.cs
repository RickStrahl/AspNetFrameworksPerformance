using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworksPerformance.Controllers
{
    public class MvcPerformanceController : Controller
    {
        //
        // GET: /MvcPerformance/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HelloWorldCode()
        {
            return new ContentResult() 
            { Content = "Hello World. Time is: " + DateTime.Now.ToString() };
        }

        public JsonResult HelloWorldJson()
        {
            return Json(new Person(), JsonRequestBehavior.AllowGet);
        }

    }
}