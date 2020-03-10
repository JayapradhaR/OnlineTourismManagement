using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Models;

namespace OnlineTourismManagement.Controllers
{
    public class PackageTypeController : Controller
    {
        // GET: PackageType
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult ViewPackageType()
        {
            IEnumerable<PackageType> packageTypes = PackageTypeBL.GetPackageTypes();
            ViewBag.Types = packageTypes;
            return View();
        }
        [HttpGet]
        public ViewResult AddPackageType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPackageType(PackageTypeViewModel packageType)
        {
            if(ModelState.IsValid)
            {
                PackageType package = AutoMapper.Mapper.Map<PackageTypeViewModel, PackageType>(packageType);
                PackageTypeBL.AddPackageType(package);
                TempData["Message"] = "Package type added";
                return RedirectToAction("ViewPackageType");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                PackageType pack = PackageTypeBL.GetPackageTypeById(id);
                PackageTypeViewModel package = AutoMapper.Mapper.Map<PackageType, PackageTypeViewModel>(pack);
                return View(package);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "PackageId,PackageTypeName")]PackageTypeViewModel packageDetails)
        {
            PackageType package = PackageTypeBL.GetPackageTypeById(packageDetails.PackageTypeId);
            package.PackageTypeName = packageDetails.PackageTypeName;
            PackageTypeBL.UpdatePackageType(package);
            TempData["Message"] = "Package type updated";
            return RedirectToAction("ViewPackage");
        }
        public ActionResult Delete(int id)
        {
            PackageTypeBL.DeletePackageType(id);
            TempData["Message"] = "Package Deleted";
            return RedirectToAction("ViewPackage");
        }
    }
}