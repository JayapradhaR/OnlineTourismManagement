using OnlineTourismManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTourismManagement.Controllers
{
    public class PackageController : Controller
    {
        // GET: Package
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult CreatePackage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePackage(PackageViewModel packages)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("HomePage", "Home");
            }
            return View();
        }
    }
}