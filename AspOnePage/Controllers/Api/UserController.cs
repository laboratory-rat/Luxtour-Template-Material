using AspOnePage.Interfaces;
using AspOnePage.Models;
using AspOnePage.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AspOnePage.Controllers.Api
{
    [Authorize(Roles = "administrator, manager")]
    public class UserController : ApiController
    {
        public IUserRepository<ApplicationUser, string> Repo { get; set; }

        public UserController()
        {
            Repo = new UserRepository();
        }

        public UserList Get(int count = -1, int page = 1)
        {
            UserList list;

            var l = Repo.Take(10, 1, x => x.Email != "", x => x.Email);

            list = new UserList(l, l.Count(), 1);

            return list;
        }
    }
}
