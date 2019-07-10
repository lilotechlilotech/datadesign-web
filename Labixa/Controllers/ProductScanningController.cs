using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labixa.Models;
using Outsourcing.Service;
using Outsourcing.Data.Models;
using PagedList;
using Labixa.ViewModels;
using Labixa.Helpers;
using Outsourcing.Core.Common;
using Labixa.Areas.Admin.ViewModel;
using Outsourcing.Core.Framework.Controllers;
using AutoMapper;
using Microsoft.Ajax.Utilities;

namespace Labixa.Controllers
{
    public class ProductScanningController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productcategoryService;
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttributeService;
        private readonly IStaffService _staffService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductRelationshipService _productRelationshipService;
        //private readonly I ;



        public ProductScanningController(IProductService productService, IBlogService blogService,
            IWebsiteAttributeService websiteAttributeService, IBlogCategoryService blogCategoryService,
            IStaffService staffService, IProductAttributeMappingService productAttributeMappingService,
            IProductRelationshipService productRelationshipService, IProductCategoryService productcategoryService)
        {
            this._productService = productService;
            this._blogService = blogService;
            this._websiteAttributeService = websiteAttributeService;
            this._blogCategoryService = blogCategoryService;
            this._staffService = staffService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productRelationshipService = productRelationshipService;
            this._productcategoryService = productcategoryService;
        }
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
        public ActionResult BlogHome()
        {
            var listBlogHome = _blogService.GetBlogs().Where(p => p.BlogCategoryId == 3).Take(3).ToList();
            return PartialView("_ListBlogHome",listBlogHome);
        }
        public ActionResult BlogDetail(string slug)
        {
            if (slug!="")
            {
                var blog = _blogService.GetBlogByUrlName(slug);
                return View(blog);
            }
            return RedirectToAction("Index");
        }
        public ActionResult ListBlog()
        {
            var list = _blogService.GetBlogByCategoryId(3).Take(3).ToList();
            return View(list);
        }
	}
}