using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class QuestionaireViewModel
    {
        public List<SelectListItem> InformMethods { set; get; }
        public List<SelectListItem> ContactMethods { set; get; }
    }
}