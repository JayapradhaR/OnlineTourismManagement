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
        //Viewing package types
        public ViewResult ViewPackageType()
        {
            IEnumerable<PackageType> packageTypes = PackageTypeBL.GetPackageTypes();
            ViewBag.PackageTypes = packageTypes;
            return View();
        }
        //Add the package type
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
                PackageTypeBL.AddPackageType(package); //Call function to add the package details
                TempData["Message"] = "Package type added"; // Tempdata to print the message 
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
                PackageTypeViewModel package = AutoMapper.Mapper.Map<PackageType, PackageTypeViewModel>(pack); //Mapping 
                return View(package);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "PackageTypeId,PackageTypeName")]PackageTypeViewModel packageDetails)
        {
            PackageType package = PackageTypeBL.GetPackageTypeById(packageDetails.PackageTypeId);
            package.PackageTypeName = packageDetails.PackageTypeName;
            PackageTypeBL.UpdatePackageType(package);
            TempData["Message"] = "Package type updated";
            return RedirectToAction("ViewPackageType");
        }
        public ActionResult Delete(int id)
        {
            PackageTypeBL.DeletePackageType(id);
            TempData["Message"] = "Package Deleted";
            return RedirectToAction("ViewPackageType");
        }
    }
}