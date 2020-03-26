using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Models;

namespace OnlineTourismManagement.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PackageTypeController : Controller
    {
        IPackageTypeBL package;
        public PackageTypeController()
        {
            package = new PackageTypeBL();
        }
        // GET: PackageType
        public ActionResult Index()
        {
            return View();
        }
        //Viewing package types
        public ViewResult ViewPackageType()
        {
            IEnumerable<PackageType> packageType = package.GetPackageTypes();
            ViewBag.PackageTypes = packageType;
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
            if (ModelState.IsValid)
            {
                PackageType packages = AutoMapper.Mapper.Map<PackageTypeViewModel, PackageType>(packageType);
                package.AddPackageType(packages); //Call function to add the package details
                TempData["Messages"] = "Package type added"; // Tempdata to print the message 
                return RedirectToAction("ViewPackageType");
            }
            return View();
        }
        //Edit package type
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                PackageType pack = package.GetPackageTypeById(id);
                PackageTypeViewModel packages = AutoMapper.Mapper.Map<PackageType, PackageTypeViewModel>(pack); //Mapping 
                return View(packages);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "PackageTypeId,PackageTypeName")]PackageTypeViewModel packageDetails)
        {
            PackageType packages = package.GetPackageTypeById(packageDetails.PackageTypeId);
            packages.PackageTypeName = packageDetails.PackageTypeName;
            package.UpdatePackageType(packages);
            TempData["Messages"] = "Package type updated";
            return RedirectToAction("ViewPackageType");
        }
        //Delete package type
        public ActionResult Delete(int id)
        {
            package.DeletePackageType(id);
            TempData["Messages"] = "Package Deleted";
            return RedirectToAction("ViewPackageType");
        }
    }
}