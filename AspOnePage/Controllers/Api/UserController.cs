using AspOnePage.Interfaces;
using AspOnePage.Models;
using AspOnePage.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace AspOnePage.Controllers.Api
{
    //[Authorize(Roles = "administrator, manager")]
    public class UserController : ApiController
    {
        public IUserRepository<ApplicationUser, string> Repo { get; set; }

        public UserController()
        {
            Repo = new UserRepository();
        }

        public UserList Get(int count, int page = 1)
        {
            UserList list;

            var l = Repo.Take(10, 1, x => x.Email != "", x => x.Email);

            list = new UserList(l, l.Count(), 1);

            return list;
        }

        public UserShort Get(string id)
        {
            var user = Repo.Find(x => x.Id == id);

            return user == null ? null : new UserShort(user);
        }

        public UserShort[] Get(string search, string param, bool desc = false)
        {
            Func<ApplicationUser, bool> predicate;
            Func<ApplicationUser, string> order;

            switch (search)
            {
                case "email":
                    predicate = x => x.Email.Contains(param);
                    order = x => x.Email;
                    break;
                case "firstName":
                    predicate = x => x.FirstName.Contains(param);
                    order = x => x.FirstName;
                    break;
                case "secondName":
                    predicate = x => x.SecondName.Contains(param);
                    order = x => x.SecondName;
                    break;

                default:
                    predicate = x => x.Email.Contains(param);
                    order = x => x.Email;
                    break;
            }

            var users = Repo.All(predicate, order, desc);

            return users.Select(x => new UserShort(x)).ToArray();
        }

        public UserShort[] Get()
        {
            var users = Repo.All(x => true, x => x.Email, false);
            return users.Select(x => new UserShort(x)).ToArray();

        }

        public async Task<string> Put(UserRegistration model)
        {
            if (!ModelState.IsValid)
                return "error";

            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            ApplicationUser user = new ApplicationUser(model);

            string[] roles = Roles.GetRolesForUser();

            var result = await manager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                if (model.IsAgent || (!model.IsManager && !model.IsAdministrator))
                    await manager.AddToRoleAsync(user.Id, "agent");

                if (model.IsManager && (roles.Contains("manager") || roles.Contains("administrator")))
                    await manager.AddToRoleAsync(user.Id, "manager");

                if (model.IsAdministrator && roles.Contains("administrator"))
                    await manager.AddToRoleAsync(user.Id, "administrator");

                if(model.SendEmail)
                {
                    await manager.SendEmailAsync(user.Id, "Test", "Test message from site.");
                }

                return "success";
            }

            return "error";
        }

        protected override void Dispose(bool disposing)
        {
            if(Repo != null)
                Repo.Dispose();

            base.Dispose(disposing);
        }


    }
}
