using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetFrameworksPerformance
{
    public partial class HelloWorld_CodeBehind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello World. Time is: " + DateTime.Now.ToString() );
            Response.End();
        }
    }
}