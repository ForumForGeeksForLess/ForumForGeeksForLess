
using ForumForGeeksForLess.BL.interfaceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumForGeeksForLess.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBL forumService;
        public HomeController(IRepositoryBL serv)
        {
            forumService = serv;
        }

        public ActionResult Index()
        {

            var el = forumService.GetAllSectionAndSub();






            return View();
        }

        protected override void Dispose(bool disposing)
        {
            forumService.Dispose();
            base.Dispose(disposing);
        }

    }
}