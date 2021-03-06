﻿using ForumForGeeksForLess.BL.interfaceDTO;
using ForumForGeeksForLess.Models.ForumWebModel;
using Microsoft.AspNet.Identity;
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

        [Authorize]
        public ActionResult Create(int id)
        {
            return View(new MessageInTheTopicWEB { idtopicInTheForum = id});
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "idtopicInTheForum,text,caption")] MessageInTheTopicWEB model)
        {
            if (ModelState.IsValid)
            {
                model.idIdent = User.Identity.GetUserId();
                forumService.saveMessage(model);
                return RedirectToAction("Index", new { id = model.idtopicInTheForum });
            }
            return View(model);
        }


        [Authorize]
        public ActionResult Edit(int id)
        {
            var el = forumService.FindMessage(id);
            if(el.idIdent!=User.Identity.GetUserId())
                return RedirectToAction("Index", new { id = el.idtopicInTheForum });
            return View(el);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,idIdent,idtopicInTheForum,text,caption")] MessageInTheTopicWEB model)
        {
            if (ModelState.IsValid)
            {
                if (model.idIdent == User.Identity.GetUserId())
                    forumService.editMessage(model);
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