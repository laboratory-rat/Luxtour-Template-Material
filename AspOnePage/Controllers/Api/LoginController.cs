using AspOnePage.Models;
using Microsoft.AspNet.Identity;
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

    public class LoginController : ApiController
    {
        protected ApplicationUserManager _manager { get; set; } = null;
        public ApplicationUserManager Manager
        {
            get { return _manager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { _manager = value; }
        }

        protected ApplicationSignInManager _signInManager { get; set; } = null;
        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>(); }
            set { _signInManager = value; }
        }

        public async Task<string> Post(UserLogin model)
        {
            try
            {
                // TMP
                var user = await Manager.FindByEmailAsync(model.Email);

                if(user != null)
                    await Manager.UpdateSecurityStampAsync(user.Id);

                //end tmp

                var status = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                switch (status)
                {
                    case SignInStatus.Success:
                        return "success";
                    case SignInStatus.RequiresVerification:
                        return "verivication";
                    case SignInStatus.LockedOut:
                        return "lock";
                    case SignInStatus.Failure:
                        return "fail";
                    default:
                        return "error";
                }
            }
            catch(Exception ex)
            {
                var e = ex;
                return "";
            }


        }
    }
}
