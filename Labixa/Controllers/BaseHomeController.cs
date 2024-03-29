﻿using Labixa.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Controllers
{
    public class BaseHomeController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = "en";
            // Validate culture name
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            HttpCookie cookie;
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            //cultureName = "vi";
            else
            {
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
                 cookie = new HttpCookie("_culture", cultureName);
                Response.SetCookie(cookie);
            }
            cultureName = "en";
            cookie = new HttpCookie("_culture", cultureName);
            Response.SetCookie(cookie);
            
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe
            //cultureName = "vi";
            //cultureName = "en";
            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;



            return base.BeginExecuteCore(callback, state);
        }
    }
}