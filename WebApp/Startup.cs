using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using WebApp.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;



[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            seedDatabase();
        }

        private void seedDatabase()
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext())
            );

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            var roles = new List<IdentityRole> {
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "User" }
            };

            var users = new List<ApplicationUser>
            {
                new ApplicationUser{ UserName="mark", Email="mark@mark.com" },
                new ApplicationUser{ UserName="dave", Email="dave@dave.com" },
                new ApplicationUser{ UserName="sarah", Email="dave@mark.com" }
            };

            foreach (IdentityRole role in roles)
            {
                var result = roleManager.Create(role);
            }

            // asp.net identity default password policy is required length of 6
            foreach (ApplicationUser user in users)
            {
                var result = userManager.Create(user, "password_1");
                if (result.Succeeded) userManager.AddToRole(user.Id, "User");
            }

            var admin = userManager.FindByName("mark");
            userManager.AddToRole(admin.Id, "Admin");

        }

    }
}
