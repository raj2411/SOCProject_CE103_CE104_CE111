using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOC_WebApplication1.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Greet(string name)
        {
            return "welcome " + name;
        }
    }
}
