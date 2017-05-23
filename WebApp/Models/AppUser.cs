using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace WebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Country { get; set; }
    }
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("DefaultConnection")
        {

        }
    }
}