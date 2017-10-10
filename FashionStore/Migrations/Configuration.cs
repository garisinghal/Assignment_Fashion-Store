namespace FashionStore.Migrations
{
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Web;
    using System.Data.Entity.Migrations;
    using FashionStore.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FashionStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FashionStore.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser { UserName = "admin@gmail.com" };
            var guestUser = new ApplicationUser { UserName = "guest@guest.com" };

            userManager.Create(user, "abc123"); //strong password!#@$!
            userManager.Create(guestUser, "guest1"); //strong password!#@$!

            roleManager.Create(new IdentityRole { Name = "Admin" });
            userManager.AddToRole(user.Id, "Admin");
        }
    }
}
