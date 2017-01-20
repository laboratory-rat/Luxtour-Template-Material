namespace AspOnePage.Migrations
{
    using AspOnePage.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<AspOnePage.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if(!context.Roles.Any(x => x.Name == "administrator" || x.Name == "manager" || x.Name == "agent"))
            {
                context.Roles.AddOrUpdate(
                    p => p.Name,
                    new IdentityRole("administrator"),
                    new IdentityRole("manager"),
                    new IdentityRole("agent"));

                context.SaveChanges();
            }

            
            if(!context.Users.Any(x => x.Email == "oleg.timofeev20@gmail.com"))
            {
                var oleg = context.Users.Add(new ApplicationUser()
                {
                    FirstName = "Oleg",
                    SecondName = "Timofeev",
                    Email = "oleg.timofeev20@gmail.com",
                    UserName = "oleg.timofeev20@gmail.com",
                    PhoneNumber = "0508837161",
                    Birthday = DateTime.Today,
                    EmailConfirmed = true,
                });

                context.SaveChanges();

                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                oleg.PasswordHash = manager.PasswordHasher.HashPassword("lxonline");
                manager.AddToRoleAsync(oleg.Id, "administrator").Wait();
            }

            if(!context.General.Any(x => x.Key == "SITE_TITLE"))
            {
                context.General.Add(new GeneralModels { Key = "SITE_TITLE", Value = "Luxtour Online" });
            }

            if (!context.General.Any(x => x.Key == "LUXTOUR_TOKEN"))
                context.General.Add(new GeneralModels { Key = "LUXTOUR_TOKEN", Value = "XXXXXXXXXXXXXXXXX" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
