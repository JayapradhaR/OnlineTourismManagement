using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineTourismManagement.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PackageController : Controller
    {
        IPackageBL packages;
        public PackageController()
        {
            packages = new PackageBL();
        }
        // GET: Package
        public ActionResult Index()
        {
            return View();
        }
        //View package details
        public ViewResult ViewPackage()
        {
            IEnumerable<Package> package = packages.GetPackages();
            ViewBag.Packages = package;
            return View();
        }
        //Add packages
        [HttpGet]
        public ViewResult CreatePackage()
        {
            IPackageTypeBL packageType = new PackageTypeBL();
            ViewBag.PackageTypes = new SelectList(packageType.GetPackageTypes(), "PackageTypeId", "PackageTypeName");
            return View();
        }
        [HttpPost]
        public ActionResult CreatePackage(PackageViewModel packageDetails)
        {
            try
            {
                IPackageTypeBL packageType = new PackageTypeBL();
                ViewBag.PackageTypes = new SelectList(packageType.GetPackageTypes(), "PackageTypeId", "PackageTypeName");
                if (ModelState.IsValid)
                {
                    Package package = AutoMapper.Mapper.Map<PackageViewModel, Package>(packageDetails);
                    packages.AddPackage(package);
                    TempData["Message"] = "Package Added";
                    return RedirectToAction("ViewPackage");
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        //Edit package details
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Package pack = packages.GetPackageById(id);
            PackageViewModel package = AutoMapper.Mapper.Map<Package, PackageViewModel>(pack);
            return View(package);
        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "PackageId,PackagePrice,PackageName,Duration,Availability")]PackageViewModel packageDetails)
        {
            Package package = packages.GetPackageById(packageDetails.PackageId);
            package.PackageName = packageDetails.PackageName;
            package.PackagePrice = packageDetails.PackagePrice;
            package.Duration = packageDetails.Duration;
            package.Availability = packageDetails.Availability;
            package.UpdationDate = DateTime.Now;
            packages.UpdatePackage(package);
            TempData["Message"] = "Package updated";
            return RedirectToAction("ViewPackage");
        }
        //Delete packages
        public ActionResult Delete(int id)
        {
            packages.DeletePackage(id);
            TempData["Message"] = "Package Deleted";
            return RedirectToAction("ViewPackage");
        }
    }
}