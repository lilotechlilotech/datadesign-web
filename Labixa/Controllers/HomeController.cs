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

    public class HomeController : BaseHomeController
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



        public HomeController(IProductService productService, IBlogService blogService,
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
        public ActionResult Index()
        {
            var model = _productService.GetAllProducts().OrderByDescending(x => x.DateCreated);
            var category = _productcategoryService.GetProductCategoriesHome().Where(p => p.Deleted == false).ToList();
            var products = _productService.GetAllProducts().Where(p => p.Deleted == false);
            category.ForEach(x =>
            {
                x.Products = products.Where(c => x.Id == c.ProductCategoryId).ToList();
            });
            var blog1 = _blogService.GetBlogById(1);
            var blog2 = _blogService.GetBlogById(2);
            //var blogimages = _;
            ViewData["blog1"] = blog1;
            ViewData["blog2"] = blog2;
            ViewData["category"] = category;
            return View(model);
        }
        public ActionResult Banner()
        {
            var model = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type.Equals("Banner")).ToList();
            return PartialView("_BannerHome", model);
        }
        public ActionResult About()
        {

            return View();
        }


        #region
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult getHeader()
        {
            var websiteAttribute = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type.ToLower().Equals("social")).ToList();
            ViewBag.social = websiteAttribute;
            var list = _productcategoryService.GetProductCategories();
            return PartialView("_Header", list);
        }
        public ActionResult getFooter()
        {
            var websiteAttribute = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type.ToLower().Equals("social")).ToList();
            ViewBag.social = websiteAttribute;
            return PartialView("_Footer");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult about_us()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Products()
        {

            return View();
        }
        public ActionResult DetailProduct()
        {
            return View();
        }
        public PartialViewResult GetBlog()
        {
            var model = _blogService.GetBlogs().OrderByDescending(p => p.DateCreated).Take(4).ToList();
            return PartialView("_Blog", model);
        }
        public ActionResult PolicyBuy()
        {
            var model = _blogService.GetBlogByUrlName("chinh-sach-mua-hang");
            return View(model);
        }
        public ActionResult PolicyReturn()
        {
            var model = _blogService.GetBlogByUrlName("chinh-sach-doi-tra");
            return View(model);
        }
        public ActionResult SizeTable()
        {
            var model = _blogService.GetBlogByUrlName("bang-size");
            return View(model);
        }
        #endregion

        #region[Multi Language]

        public ActionResult SetCulture(string slug)
        {
            //SetCultu(slug);
            //return RedirectToAction("Index", "Home");
            slug = CultureHelper.GetImplementedCulture(slug);
            HttpCookie cookie = Request.Cookies["_culture"];
            if (slug == null)
            {
                slug = ViewBag.cookiValues;
            }
            if (cookie != null)
            {
                cookie.Value = slug;
            }
            else
            {
                cookie = new HttpCookie("_culture")
                {
                    Value = slug,
                    Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        [ValidateInput(false)]
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult SendMessage(StaffFormModel obj, bool continueEditing)
        {
            obj.Phone = "09090909090";
            if (ModelState.IsValid)
            {
                Staff item = Mapper.Map<StaffFormModel, Staff>(obj);
                _staffService.CreateStaff(item);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
