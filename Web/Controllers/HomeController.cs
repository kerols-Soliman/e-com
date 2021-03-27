using BL.AppServices;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        CategroyAppService categroyAppServices = new CategroyAppService();
        public ActionResult Index()
        {
            List<CategroyViewModel> categories = categroyAppServices.GetAllCategroy();
            
            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}