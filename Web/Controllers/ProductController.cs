using BL.AppServices;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
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
        [Authorize(Roles ="admin")]
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

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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
    }
}