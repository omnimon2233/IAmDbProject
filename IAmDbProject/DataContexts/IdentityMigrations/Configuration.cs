namespace IAmDbProject.DataContexts.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IAmDbProject.DataContexts.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\IdentityMigrations";
        }

        protected override void Seed(IAmDbProject.DataContexts.IdentityDb context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                roleManager.Create(new IdentityRole { Name = "admin" });
            }

            if (!context.Roles.Any(r => r.Name == "supervolunteer"))
            {
                roleManager.Create(new IdentityRole { Name = "supervolunteer" });
            }
            if (!context.Roles.Any(r => r.Name == "volunteer"))
            {
                roleManager.Create(new IdentityRole { Name = "volunteer" });
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@user.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "admin@user.com",
                    UserName = "admin@user.com"
                };
                userManager.Create(user, "Pass123!");
                userManager.AddToRole(user.Id, "admin");
            }
        }
    }
}
