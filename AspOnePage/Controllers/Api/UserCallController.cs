using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspOnePage.Controllers.Api
{
    public class UserCallController : ApiController
    {
        public string Post(CallModel model)
        {
            return "success";
        }
    }


}
