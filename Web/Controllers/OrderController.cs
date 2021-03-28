using BL.AppServices;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        OrderAppServices orderAppServices = new OrderAppServices();
        CartAppService cartAppService = new CartAppService();
        // GET: Order

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var Order= orderAppServices.GetMyOder(userId);
            return View(Order);
        }
        [HttpGet]
        public ActionResult Create(string cartId)
        {
            CartAppService cartAppService = new CartAppService();
            ProductCartAppService productCartApp = new ProductCartAppService();
            Cart cart = cartAppService.GetById(cartId);
            orderAppServices.InsertProductToOrder(cart);
            //cartAppService.Delete(cart.User_Id);
            foreach(var item in cart.ProductsCart)
            {
                productCartApp.DeleteProductCart(item.Id);
            }
            
            return RedirectToAction("Index","cart");
        }
    }
}