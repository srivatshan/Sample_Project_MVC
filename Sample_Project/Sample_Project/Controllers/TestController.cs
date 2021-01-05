using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample_Project.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        [HttpGet]
        public string Testing()
        {
            return "Working";
        }


    }
}
