using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;

namespace OnlineTourismManagement.Controllers
{
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
        //View package by package type id
        public ActionResult ViewPackageByType(int id)
        {
            IEnumerable<Package> pack = packages.GetPackageByTypeId(id);
            return View("ViewPackage", pack);
        }
        //View package details
        public ViewResult ViewPackage()
        {
            IEnumerable<Package> package = packages.GetPackages();
            return View(package);
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
        [ValidateAntiForgeryToken]
        public ActionResult CreatePackage(PackageViewModel packageDetails)
        {
            try
            {
                IPackageTypeBL packageType = new PackageTypeBL();
                ViewBag.PackageTypes = new SelectList(packageType.GetPackageTypes(), "PackageTypeId", "PackageTypeName");
                if (ModelState.IsValid)
                {
                    string fileName = Path.GetFileNameWithoutExtension(packageDetails.ImageFile.FileName);
                    string extension = Path.GetExtension(packageDetails.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    packageDetails.ImageSource ="~/Images/PackageImages/"+fileName;
                    Package package = AutoMapper.Mapper.Map<PackageViewModel, Package>(packageDetails);
                    fileName = Path.Combine(Server.MapPath("~/Images/PackageImages/"), fileName);
                    packageDetails.ImageFile.SaveAs(fileName);
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
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "PackageId,PackagePrice,PackageName,Duration,Availability,ImageSource,ImageFile")]PackageViewModel packageDetails)
        {
            string fileName = Path.GetFileNameWithoutExtension(packageDetails.ImageFile.FileName);
            string extension = Path.GetExtension(packageDetails.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            packageDetails.ImageSource = "~/Images/PackageImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/PackageImages/"), fileName);
            packageDetails.ImageFile.SaveAs(fileName);
            Package package = packages.GetPackageById(packageDetails.PackageId);
            package.PackageName = packageDetails.PackageName;
            package.PackagePrice = packageDetails.PackagePrice;
            package.Duration = packageDetails.Duration;
            package.Availability = packageDetails.Availability;
            package.UpdationDate = DateTime.Now;
            package.ImageSource = packageDetails.ImageSource;
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
        public ActionResult ViewDetails(int id)
        {
            IEnumerable<Package> package = packages.GetPackages();
            return View(package);
        }
    }
}