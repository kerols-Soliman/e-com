using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        RoleAppService roleAppService = new RoleAppService();

        // GET: Roles
       
        
        public ActionResult create() => View();
        [HttpPost]
        public ActionResult Create(string RoleName)
        {
            if (RoleName != null)
            {
                roleAppService.Create(RoleName);
            }
            ViewBag.RoleName = RoleName;
            return View();
        }
        
    }
}