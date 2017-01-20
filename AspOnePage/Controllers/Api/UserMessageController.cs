using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspOnePage.Controllers.Api
{
    public class UserMessageController : ApiController
    {
        public string Post(UserMessageModel model)
        {
            return "success";
        }
    }


}
