using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labixa.Models;
using Outsourcing.Service;
using Outsourcing.Data.Models;
using PagedList;
using Labixa.ViewModels;
using Labixa.Helpers;

namespace Labixa.Controllers
{
    public class BlogNewsController : BaseHomeController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productcategoryService;
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttributeService;
        private readonly IStaffService _staffService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductRelationshipService _productRelationshipService;



        public BlogNewsController(IProductService productService, IBlogService blogService,
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
        // GET: /Blog/
        public ActionResult Index(int? page = 1)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var blog = _blogService.GetBlogs().ToPagedList(pageNumber, pageSize);
            return View(blog);
        }
        public ActionResult Detail(string slug)
        {
            var model = _blogService.GetBlogByUrlName(slug);
            return View(model);
        }
        public ActionResult RecentPost()
        {
            var model = _blogService.GetBlogs().OrderByDescending(p => p.DateCreated).Take(5);
            return PartialView("_recentBlog", model);
        }
        public ActionResult BrandList()
        {
            var model = _websiteAttributeService.GetWebsiteAttributes().Where(p => p.Type.Equals("Brand")).ToList();
            return PartialView("_BrandList", model);
        }
    }
}