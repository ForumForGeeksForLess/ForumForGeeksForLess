﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumForGeeksForLess.Controllers
{
    public class viewTopicController : Controller
    {
        // GET: viewTopic
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}