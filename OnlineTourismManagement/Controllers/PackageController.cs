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
        public ViewResult ViewPackage()
        {
            IEnumerable<Package> package = PackageBL.GetPackages();
            ViewBag.Packages = package;
            return View();
        }
        [HttpGet]
        public ViewResult CreatePackage()
        {
            ViewBag.PackageTypes = new SelectList(PackageTypeBL.GetPackageTypes(), "PackageTypeId", "PackageTypeName");
            return View();
        }
        [HttpPost]
        public ActionResult CreatePackage(PackageViewModel packages)
        {
            if (ModelState.IsValid)
            {
                Package package = AutoMapper.Mapper.Map<PackageViewModel, Package>(packages);
                PackageBL.AddPackage(package);
                TempData["Message"] = "Package Added";
                return RedirectToAction("ViewPackage");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Package pack = PackageBL.GetPackageById(id);
            PackageViewModel package = AutoMapper.Mapper.Map<Package, PackageViewModel>(pack);
            return View(package);
        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "PackageId,PackagePrice,PackageName,Duration,Availability")]PackageViewModel packageDetails)
        {
            Package package = PackageBL.GetPackageById(packageDetails.PackageId);
            package.PackageName = packageDetails.PackageName;
            package.PackagePrice = packageDetails.PackagePrice;
            package.Duration = packageDetails.Duration;
            package.Availability = packageDetails.Availability;
            package.UpdationDate = DateTime.Now;
            PackageBL.UpdatePackage(package);
            TempData["Message"] = "Package updated";
            return RedirectToAction("ViewPackage");
        }
        public ActionResult Delete(int id)
        {
            PackageBL.DeletePackage(id);
            TempData["Message"] = "Package Deleted";
            return RedirectToAction("ViewPackage");
        }
    }
}