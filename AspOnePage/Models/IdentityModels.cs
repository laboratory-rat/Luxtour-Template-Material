using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace AspOnePage.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {

        }

        public ApplicationUser(UserRegistration model)
        {
            FirstName = model.FirstName;
            SecondName = model.SecondName;
            Email = UserName = model.Email;
            PhoneNumber = model.Tel;
            Birthday = model.Birthday;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UserCity> Cities { get; set; }
        public DbSet<GeneralModels> General { get; set; }
        public DbSet<MessageModel> Messages { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}