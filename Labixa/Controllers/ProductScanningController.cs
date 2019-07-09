using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Controllers
{
    public class ProductScanningController : Controller
    {
        //
        // GET: /ProductScanning/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string ProductName)
        {
            return View();
        }
	}
}