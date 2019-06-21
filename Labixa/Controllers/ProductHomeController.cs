using Labixa.ViewModels;
using Outsourcing.Core.Common;
using Outsourcing.Data.Models;
using Outsourcing.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labixa.Controllers
{
    public class ProductHomeController : BaseHomeController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productcategoryService;
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IWebsiteAttributeService _websiteAttributeService;
        private readonly IStaffService _staffService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductRelationshipService _productRelationshipService;



        public ProductHomeController(IProductService productService, IBlogService blogService,
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
        public ActionResult Index(string slug, int? page = 1)
        {
            return View();
        }
        //public ActionResult Detail(string slug)
        //{
        //    var model = _productService.GetProductBySlug(slug);
        //    return View(model);
        //}
        //public ActionResult ProductRelate(string slug)
        //{
        //    if (slug != "")
        //    {

        //        var model = _productService.GetProducts().Where(p => p.ProductCategory.Slug.Equals(slug)).Take(4);
        //        return PartialView("_ProductRelate", model);
        //    }
        //    else
        //    {
        //        var model = _productService.GetProducts().Take(4);
        //        return PartialView("_ProductRelate", model);
        //    }
        //}
        //[HttpPost]
        //public ActionResult Addtocart(int ProdId, int Quantity)
        //{
        //    ListProductCartModel listCart = new ListProductCartModel();
        //    if (Session["Cart"] != null)
        //    {
        //        listCart = (ListProductCartModel)Session["Cart"];

        //        //kiểm tra product đã có trong cart chưa, nếu có thì cập nhật số lượng
        //        if (listCart.listProduct.Where(p => p.ProductId == ProdId).FirstOrDefault() != null)
        //        {
        //            foreach (var item in listCart.listProduct)
        //            {
        //                if (item.ProductId == ProdId)
        //                {
        //                    item.Quantity = Quantity;
        //                }
        //            }
        //            var modelCart = OrderCalculator.CalculatorCart(listCart);
        //            Session["Cart"] = modelCart;
        //        }
        //        else
        //        {
        //            //nếu không có trong cart, thì thêm product vào cart
        //            CartModel cart = new CartModel();
        //            var product = _productService.GetProductById(ProdId);
        //            cart.ProdName = product.Name;
        //            cart.ProdNameEngh = product.NameEng;
        //            cart.DescriptionEng = product.DescEng;
        //            cart.Description = product.Description;
        //            cart.slug = product.Slug;
        //            cart.ProductImage = product.ProductPictureMappings.FirstOrDefault().Picture.Url;
        //            cart.ProductId = product.Id;
        //            if (product.IsHomePage)
        //            {
        //                cart.Price = product.Price;
        //            }
        //            else
        //            {
        //                cart.Price = product.OldPrice;
        //            }
        //            cart.Quantity = Quantity;
        //            listCart.listProduct.Add(cart);
        //            var modelCart = OrderCalculator.CalculatorCart(listCart);
        //            Session["Cart"] = modelCart;
        //        }
        //    }
        //    else
        //    {
        //        //tạo mới cart đưa vào session
        //        CartModel cart = new CartModel();
        //        var product = _productService.GetProductById(ProdId);
        //        cart.ProdName = product.Name;
        //        cart.ProdNameEngh = product.NameEng;
        //        cart.DescriptionEng = product.DescEng;
        //        cart.Description = product.Description;
        //        cart.slug = product.Slug;
        //        cart.ProductImage = product.ProductPictureMappings.FirstOrDefault().Picture.Url;
        //        cart.ProductId = product.Id;
        //        if (product.IsHomePage)
        //        {
        //            cart.Price = product.Price;
                   
        //        }
        //        else
        //        {
        //            cart.Price = product.OldPrice;
        //        }
        //        cart.Quantity = Quantity;
        //        listCart.listProduct.Add(cart);
        //        var modelCart = OrderCalculator.CalculatorCart(listCart);
        //        Session["Cart"] = modelCart;
        //    }
        //    return null;
        //}
        ///// <summary>
        ///// cập nhật giỏ hàng trong Cart
        ///// </summary>
        ///// <param name="updateList"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult UpdateCart(ListProductCartModel updateList)
        //{
        //    if (updateList != null)
        //    {
        //        Session["Cart"] = updateList;
        //    }
        //    return PartialView("_Cart");
        //}
        //public ActionResult DeleteCart()
        //{
        //    Session["Cart"] = null;
        //    return RedirectToAction("Index", "Cart");
        //}
        //public ActionResult DeleteCartProduct(int Prod)
        //{
        //    ListProductCartModel listCart = new ListProductCartModel();
        //    listCart = (ListProductCartModel)Session["Cart"];
        //    var st = listCart.listProduct.Find(c => c.ProductId == Prod);
        //    listCart.listProduct.Remove(st);
        //    var modelCart = OrderCalculator.CalculatorCart(listCart);
        //    Session["Cart"] = modelCart;
        //    return RedirectToAction("Index", "Cart");
        //}
        //[HttpPost]
        //public ActionResult CheckGiftCode(string GiftCode)
        //{
        //    if (GiftCode != "")
        //    {

        //        var code = _StaffService.GetStaffs().Where(p => p.Yahoo.ToLower().Equals(GiftCode.ToLower())).FirstOrDefault();
        //        ListProductCartModel listCart = new ListProductCartModel();
        //        listCart = (ListProductCartModel)Session["Cart"];
        //        if (code != null)
        //        {
        //            listCart.GiftCode = GiftCode;
        //            listCart.GiftCodePercent = int.Parse(code.Phone);
        //            var modelCart = OrderCalculator.CalculatorCart(listCart);
        //            Session["Cart"] = modelCart;
        //        }
        //    }
        //    return RedirectToAction("Index", "Cart");
        //}
    }
}