using ForumForGeeksForLess.BL.interfaceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumForGeeksForLess.Controllers
{
    public class viewTopicController : Controller
    {

        IRepositoryBL forumService;
        public viewTopicController(IRepositoryBL serv)
        {
            forumService = serv;
        }
    
        public ActionResult Index(int id)
        {
            return View(forumService.GetMessageForun(id));
        }
        protected override void Dispose(bool disposing)
        {
            forumService.Dispose();
            base.Dispose(disposing);
        }
    }
}