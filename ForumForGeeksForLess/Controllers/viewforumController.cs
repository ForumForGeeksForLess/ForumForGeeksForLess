using ForumForGeeksForLess.BL.interfaceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumForGeeksForLess.Controllers
{
    public class viewforumController : Controller
    {
        IRepositoryBL forumService;
        public viewforumController(IRepositoryBL serv)
        {
            forumService = serv;
        }


        public ActionResult Index(int id)
        {
             return View(forumService.GetViewForum(id));
        }
        protected override void Dispose(bool disposing)
        {
            forumService.Dispose();
            base.Dispose(disposing);
        }
    }
}