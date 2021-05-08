using BL.AppServices;
using BL.ViewModel;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    [System.Web.Mvc.Authorize]
    public class ProductController : Controller
    {
        // GET: Product

        ProductAppService productAppService = new ProductAppService();
        CategroyAppService categroyAppService = new CategroyAppService();
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View(productAppService.GetAllProduct());
        }
        [System.Web.Mvc.Authorize(Roles ="admin")]
        public ActionResult Create() {

            ViewBag.Categroies = categroyAppService.GetAllCategroy();
            return View();
        }        
        [HttpPost]
        public ActionResult Create(ProductViewModel newProduct, HttpPostedFileBase Image)
        {
            

            if (!ModelState.IsValid)
            {
                ViewBag.Categroies = categroyAppService.GetAllCategroy();

                
                return View(newProduct);

            }
            if (Image != null)
            {
                string fileName = Path.GetFileName(Image.FileName);
                newProduct.Image = fileName;
                Image.SaveAs(Server.MapPath("~/Content/image/") + fileName);
            }
            

            productAppService.SaveNewProduct(newProduct);
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            ProductViewModel product= productAppService.GetProductByID(id);
            ViewBag.Categroies = categroyAppService.GetAllCategroy();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel product, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categroies = categroyAppService.GetAllCategroy();
                return View(product);

            }
            if(Image != null)
            {
                string fileName = Path.GetFileName(Image.FileName);
                product.Image = fileName;
                Image.SaveAs(Server.MapPath("~/Content/image/") + fileName);
            }
            
            productAppService.UpdateProduct(product);
            return RedirectToAction("Index");
           
        }

        [System.Web.Mvc.Authorize(Roles = "admin")]
        public ActionResult Delete(int id, int category_Id)
        {

            productAppService.DeleteProduct(id);
            return RedirectToAction("GetProductsINCategory","Category",new { id= category_Id });
        }
        [AllowAnonymous]
        public ActionResult ShowDetails(int id)
        {
            ProductViewModel product= productAppService.GetProductByID(id);
            return View(product);
        }
        [AllowAnonymous]
        public ActionResult Search(string ProductName)
        {
            var products = productAppService.GetAllProductsByName(ProductName);
            ViewBag.Product_Name = ProductName;
            return View("Index", products);
        }

        [HttpPost]
        public ActionResult Comment(int product_Id,string comment)
        {
            string User_Id = User.Identity.GetUserId();
            string UseName = User.Identity.Name;
            CommentAppService commentAppService = new CommentAppService();
            commentAppService.InsertComment(User_Id,product_Id, comment);

            IHubContext commentHub= GlobalHost.ConnectionManager.GetHubContext("CommentHub");
            commentHub.Clients.All.NotifyNewComment(UseName, product_Id, comment);


            return RedirectToAction("ShowDetails",new { id=product_Id });
        }


    }
}