﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Controllers
{
    public class BlogController : BaseHomeController
    {
        //
        // GET: /Blog/
        public ActionResult Index()
        {
            return View();
        }
	}
}