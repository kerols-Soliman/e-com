using BL.AppServices;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        CategroyAppService categroyAppService = new CategroyAppService();
        // GET: Category
        public ActionResult Index()
        {
            return View(categroyAppService.GetAllCategroy());
        }
        
        public ActionResult GetProductsINCategory(int id)
        {
            ViewBag.Category = categroyAppService.GetCategroyById(id);
            var products = categroyAppService.GetProductsInCategory(id);
            return View(products);

        }
        [Authorize(Roles = "admin")]
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(CategroyViewModel newCategory)
        {
            if (!ModelState.IsValid)
                return View(newCategory);

              bool result=categroyAppService.SaveNewCategroy(newCategory);
                if (result == false)
                {
                  ViewBag.CategoryIsExist = true;
                  return View(newCategory);
                }
               ViewBag.CategoryIsExist = false;
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            CategroyViewModel categroy = categroyAppService.GetCategroyById(id);
           
            return View(categroy);
        }
        [HttpPost]
        public ActionResult Edit(CategroyViewModel categroy)
        {
            if (!ModelState.IsValid)
            {
               
                return View(categroy);

            }

            categroyAppService.UpdateCategroy(categroy);
            return RedirectToAction("Index");

        }


        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            categroyAppService.DeleteCategroy(id);
            return RedirectToAction("Index");
        }

        public ActionResult ShowMore(int id)
        {
            ViewBag.Category = categroyAppService.GetCategroyById(id);
            var products = categroyAppService.GetProductsInCategory(id);
            return View(products);
        }
    }
}