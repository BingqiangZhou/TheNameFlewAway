using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Self_Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Configuring Self-hosting Server...");
            //get self-hosting configuration object
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            Console.WriteLine("Configuring HTTP Visit Route...");
            //configure the route
            config.Routes.MapHttpRoute
                (
                    "API Default", "{controller}/{id}", new { id = RouteParameter.Optional }
                );

            Console.WriteLine("Open Self-hosting Server...");
            //create self-hosting server
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press [Enter] To Quit.");
                Console.ReadLine();
            }
        }
    }
}
