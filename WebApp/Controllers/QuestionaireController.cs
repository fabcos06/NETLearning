using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{

    //https://www.danylkoweb.com/Blog/3-ways-to-receive-data-from-postbacks-in-aspnet-mvc-C2

    public class QuestionaireController : Controller
    {
        // GET: Questionaire
        [HttpGet]
        public ActionResult Questionaire()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessQuestionaire(string rating, bool friend, bool internet, bool poster, string contactMethod)
        {
            ViewBag.ContactMethod = contactMethod;
            var list = new List<String>();
            if (friend) list.Add("friend");
            if (internet) list.Add("internet");
            if (poster) list.Add("poster");
            ViewBag.InformMethods = list;
            return View();
        }

    }
}