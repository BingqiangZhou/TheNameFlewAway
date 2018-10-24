using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Self_Hosting.Controller
{
    public class FirstController : ApiController
    {
        [HttpGet]
        public string TestApi()
        {
            return "hello,world";
        }
    }
}
