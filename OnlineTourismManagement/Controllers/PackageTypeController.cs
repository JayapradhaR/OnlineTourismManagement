using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Models;
using System.IO;
using System;

namespace OnlineTourismManagement.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
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
            return View(packageType);
        }
        //Add the package type
        [HttpGet]
        public ViewResult AddPackageType()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackageType(PackageTypeViewModel packageType)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(packageType.ImageFile.FileName);
                string extension = Path.GetExtension(packageType.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                packageType.ImageSource = "~/Images/PackageTypeImages/" + fileName;
                PackageType packages = AutoMapper.Mapper.Map<PackageTypeViewModel, PackageType>(packageType);
                fileName = Path.Combine(Server.MapPath("~/Images/PackageTypeImages/"), fileName);
                packageType.ImageFile.SaveAs(fileName);
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
            PackageType pack = package.GetPackageTypeById(id);
            PackageTypeViewModel packages = AutoMapper.Mapper.Map<PackageType, PackageTypeViewModel>(pack); //Mapping 
            return View(packages);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "PackageTypeId,PackageTypeName,ImageSource,ImageFile")]PackageTypeViewModel packageDetails)
        {
            string fileName = Path.GetFileNameWithoutExtension(packageDetails.ImageFile.FileName);
            string extension = Path.GetExtension(packageDetails.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            packageDetails.ImageSource = "~/Images/PackageTypeImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/PackageTypeImages/"), fileName);
            packageDetails.ImageFile.SaveAs(fileName);
            PackageType packages = package.GetPackageTypeById(packageDetails.PackageTypeId);
            packages.PackageTypeName = packageDetails.PackageTypeName;
            packages.ImageSource = packageDetails.ImageSource;
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