using AspNetFrameworksPerformance.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace AspNetFrameworksPerformance
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfService
    {

        [OperationContract]
        [WebGet]
        public Stream HelloWorld()
        {
            var data = Encoding.Unicode.GetBytes("Hello World " + DateTime.Now.ToString());
            var ms = new MemoryStream(data);

            // Add your operation implementation here
            return ms;
        }
        
        [OperationContract]
        [WebGet(ResponseFormat=WebMessageFormat.Json,BodyStyle=WebMessageBodyStyle.WrappedRequest)]
        public Person HelloWorldJson()
        {
            // Add your operation implementation here
            return new Person();
        }


 

        // Add more operations here and mark them with [OperationContract]
    }
}
