using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOC_WebApplication1.Controllers
{
    public class Student1Controller : ApiController
    {
        [Route("api/student/names")]
        public IEnumerable<string> get()
        {
            return new string[] { "student1", "student2" };
        }
    }
}
