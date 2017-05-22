using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{

    //https://www.danylkoweb.com/Blog/3-ways-to-receive-data-from-postbacks-in-aspnet-mvc-C2

    public class QuestionaireController : Controller
    {
        // GET: Questionaire
        [HttpGet]
        public ActionResult Questionaire()
        {
            var qvm = new QuestionaireViewModel();
            qvm.InformMethods = new List<SelectListItem>
            {
                new SelectListItem { Text = "Awesome", Value="1" },
                new SelectListItem { Text = "Ok", Value = "2" },
                new SelectListItem { Text = "Average", Value = "3" },
                new SelectListItem { Text = "Poor", Value = "4" }
            };
            qvm.ContactMethods = new List<SelectListItem>
            {
                new SelectListItem{ Text="Phone", Value = "phone" },
                new SelectListItem{ Text="Email", Value = "email" },
                new SelectListItem{ Text="Facebook", Value = "facebook" }
            };
            return View(qvm);
        }
         
        [HttpPost]
        public ActionResult ProcessQuestionaire(QuestionaireViewModel questionaire)
        {
            ViewBag.ContactMethod = questionaire.ContactMethods;
            // if (questionaire.friend) list.Add("friend");
            // if (questionaire.internet) list.Add("internet");
            // if (questionaire.poster) list.Add("poster");
            // ViewBag.InformMethods = list;
            return View(questionaire); 
        }

    }
}