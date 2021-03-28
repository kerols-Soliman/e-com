using BL.AppServices;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        CartAppService cartAppService = new CartAppService();
        ProductCartAppService productCartAppService = new ProductCartAppService();
        // GET: Cart
        
        public ActionResult Index()
        {

            string userIdValue = User.Identity.GetUserId();
            ViewBag.userID = userIdValue;
            var p = cartAppService.GetById(userIdValue);
            return View(p);
        }
        [HttpGet]
        public ActionResult Create(int productId, int quentity)
        {
            string userIdValue = User.Identity.GetUserId();
            ViewBag.userID = userIdValue;
            
            bool result = cartAppService.SaveNewProductToCart(productId, quentity, userIdValue);
            
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult Edit(int ProductCart_Id)
        {
            ProductCart productCart= productCartAppService.GetById(ProductCart_Id);
            return View(productCart);
        }
        [HttpPost]
        public ActionResult Edit(ProductCart productCart)
        {
            productCartAppService.UpdateProductCart(productCart);
            return Redirect("Index");
        }
        [HttpGet]
        public ActionResult Delete(int ProductCart_Id)
        {
            productCartAppService.DeleteProductCart(ProductCart_Id);
            return RedirectToAction("Index");
        }
    }
}