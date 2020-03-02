using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
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
        public ActionResult ViewPackage()
        {
            IEnumerable<PackageDetails> package = Package.GetPackages();
            ViewBag.Packages = package;
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
            PackageDetails package = new PackageDetails();
            if (ModelState.IsValid)
            {
                package.PackageName = packages.PackageName;
                package.PackageType = packages.PackageType;
                package.PackagePrice = packages.PackagePrice;
                package.CreationDate = DateTime.Now;
                package.UpdationDate = DateTime.Now;
                Package.AddPackage(package);
                Response.Write("Package added");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PackageDetails pack = Package.GetPackageById(id);
            PackageViewModel package = new PackageViewModel();
            if (ModelState.IsValid)
            {
                package.PackageId = pack.PackageId;
                package.PackageName = pack.PackageName;
                package.PackagePrice = pack.PackagePrice;
                package.PackageType = pack.PackageType;
                package.CreationDate = pack.CreationDate;
                return View(package);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update(PackageViewModel packageDetails)
        {
            PackageDetails package = new PackageDetails();
            //if (ModelState.IsValid)
            //{
            package.PackageId = packageDetails.PackageId;
            package.PackageName = packageDetails.PackageName;
            package.PackagePrice = packageDetails.PackagePrice;
            package.UpdationDate = DateTime.Now;
            package.PackageType = packageDetails.PackageType;
            package.CreationDate = packageDetails.CreationDate;
            Package.UpdatePackage(package);
            TempData["Message"] = "Package updated";
            return RedirectToAction("ViewPackage");
            //}
            // return View("Edit");
        }
    }
}