using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using System.Threading;

namespace SelfHost
{
    class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                int workerThreads, ioThreads;
                ThreadPool.GetMaxThreads(out workerThreads, out ioThreads);

                Console.WriteLine("Max threads: " + workerThreads  + " io Port Threads: " + ioThreads);                

                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);


                Console.WriteLine("Server is running - press any key to quit...");
                Console.ReadLine();
            }

        } 
    }
}
