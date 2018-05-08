﻿using ForumForGeeksForLess.BL.interfaceDTO;
using ForumForGeeksForLess.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ForumForGeeksForLess.Controllers
{
    public class ViewforumController : Controller
    {
        IRepositoryBL forumService;
        public ViewforumController(IRepositoryBL serv)
        {
            forumService = serv;
        }
        public ActionResult Index(int id)
        {
             return View(forumService.GetViewForum(id));
        }


        public ActionResult Create(int id)
        {
            return View(new ForCreateTopic { idsubsectionForum = id });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsubsectionForum,Name,text,caption,notes")] ForCreateTopic model)
        {
            if (ModelState.IsValid)
            {
                model.idIdent = User.Identity.GetUserId();
                forumService.SaveTopic(model);
                return RedirectToAction("Index", new { id = model.idsubsectionForum });
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