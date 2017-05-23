using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            seedIdentityDatabase();
        }

        private void seedIdentityDatabase()
        {

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            // clear all stored roles and users
            List<IdentityUser> currentUsers = userManager.Users.ToList();
            if (currentUsers != null)
            {
                foreach (IdentityUser currentUser in currentUsers)
                {
                    userManager.Delete(currentUser);
                }
            }

            List<IdentityRole> currentRoles = roleManager.Roles.ToList();
            if (currentRoles != null)
            {
                foreach (IdentityRole currentRole in currentRoles)
                {
                    roleManager.Delete(currentRole);
                }
            }

            // seed with our users and roles
            String[] users = { "mark", "sarah", "dave" };
            for (int i = 0; i < users.Length; i++)
            {
                var user = new IdentityUser() { UserName = users[i] };
                userManager.Create(user, "password_1");
            }

            String[] roles = { "administrator", "moderator", "developer" };
            for (int i = 0; i < roles.Length; i++)
            {
                var role = new IdentityRole() { Name = roles[i] };
                roleManager.Create(role);
            }

            // assign users to roles
            IdentityUser user1 = userManager.FindByName("mark");
            if (user1 != null)
            {
                userManager.AddToRole(user1.Id, "administrator");
            }

        }

    }
}
