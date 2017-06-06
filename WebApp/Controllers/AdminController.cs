using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using Microsoft.AspNet.Identity;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult showEvents()
        {
            var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = UserManager.FindByName(User.Identity.Name);
            var logger = new Logger();
            var model = logger.getEvents(user.Id);
            return View(model);
        }
    }
}