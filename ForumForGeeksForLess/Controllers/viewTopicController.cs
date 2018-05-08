using ForumForGeeksForLess.BL.interfaceDTO;
using ForumForGeeksForLess.Models.DBModel;
using Microsoft.AspNet.Identity;
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


        public ActionResult Create(int id)
        {
            return View(new messageInTheTopicWEB { idtopicInTheForum = id});
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "idtopicInTheForum,Name,text,caption")] messageInTheTopicWEB model)
        {
            if (ModelState.IsValid)
            {
                model.idIdent = User.Identity.GetUserId();
                forumService.saveMessage(model);
                return RedirectToAction("Index", new { id = model.idtopicInTheForum });
            }
            return View(model);
        }







        protected override void Dispose(bool disposing)
        {
            forumService.Dispose();
            base.Dispose(disposing);
        }
    }
}