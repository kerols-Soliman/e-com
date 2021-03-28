using BL.AppServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        FavoriteProductAppService FavProduct = new FavoriteProductAppService();
        // GET: Faviorate
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AddProduct_TO_Faviorate(int id)
        {
            string userIdValue = User.Identity.GetUserId();

            ViewBag.userID = userIdValue;
            bool result = FavProduct.SaveNewProductToFaviorate(id, userIdValue);

            return RedirectToAction("My_FaviorateProduct");
        }
        public ActionResult My_FaviorateProduct()
        {
            string userIdValue = User.Identity.GetUserId();
            return View(FavProduct.GetProductsINFaviorate(userIdValue));
        }
        public ActionResult DeleteFaviorateProduct(int id)
        {

            FavProduct.DeleteProductFromFaviorate(id);
            return RedirectToAction("My_FaviorateProduct", "Favorite"); 
        }
    }
}