using Outsourcing.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Controllers
{
    public class OnSaleController : BaseHomeController
    {
        private readonly IProductService _productService;

        public OnSaleController(IProductService productService)
        {
            this._productService = productService;
        }
       
        public ActionResult Index(int? page = 1)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            //roi demo di, loi j
            var model = _productService.GetAllProducts().Where(p=>p.IsHomePage).ToPagedList(pageNumber, pageSize);
            return View(model);
        }
        
	}
}