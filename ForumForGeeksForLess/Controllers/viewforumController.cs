using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumForGeeksForLess.Controllers
{
    public class viewforumController : Controller
    {
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}