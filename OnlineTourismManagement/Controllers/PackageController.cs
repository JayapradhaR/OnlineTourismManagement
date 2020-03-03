using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;
using System;
using System.Collections.Generic;
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
            if (ModelState.IsValid)
            {
                PackageDetails package=AutoMapper.Mapper.Map<PackageViewModel,PackageDetails>(packages);
                Package.AddPackage(package);
                TempData["Message"] = "Package Added";
                return RedirectToAction("ViewPackage");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                PackageDetails pack = Package.GetPackageById(id);
                 PackageViewModel package = AutoMapper.Mapper.Map<PackageDetails, PackageViewModel>(pack);
                return View(package);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "PackageId,PackagePrice, PackageName")]PackageViewModel packageDetails)
        {
            PackageDetails package = Package.GetPackageById(packageDetails.PackageId);
            package.PackageName = packageDetails.PackageName;
            package.PackagePrice = packageDetails.PackagePrice;
            package.UpdationDate = DateTime.Now;
            Package.UpdatePackage(package);
            TempData["Message"] = "Package updated";
            return RedirectToAction("ViewPackage");
        }
        public ActionResult Delete(int id)
        {
            Package.DeletePackage(id);
            TempData["Message"] = "Package Deleted";
            return RedirectToAction("ViewPackage");
        }
    }
}