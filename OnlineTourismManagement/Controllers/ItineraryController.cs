using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Web.Mvc;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;

namespace OnlineTourismManagement.Controllers
{
    [Authorize]
    public class ItineraryController : Controller
    {
        IItineraryBL itineraryBL;
        PackageBL packageBL;
        IUserBL customer;
        public ItineraryController()
        {
            itineraryBL = new ItineraryBL();
            packageBL = new PackageBL();
            customer = new AccountBL();
        }
        // GET: Itinerary
        public ViewResult Index()
        {
            return View();
        }
        //Viewing itinerary details
        public ActionResult ViewItinerary(int id,string packageName)
        {
            IEnumerable<Itinerary> itineraries = itineraryBL.GetItineraryByPackage(id);
            ViewBag.Package = packageName;
            return View(itineraries);
        }
        public ActionResult ViewDetails(int id)
        {
            dynamic details= new ExpandoObject();
            Package package =packageBL.GetPackageById(id);
            IEnumerable<Itinerary> itineraries = itineraryBL.GetItineraryByPackage(id);
            details.itinerary = itineraries;
            details.package = package;
            return View(details);

        }
        [HttpGet]
        public ViewResult AddItinerary(int id, int duration)
        {
            TempData["Id"] = id;
            TempData["Duration"] = duration;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItinerary(ItineraryViewModels itineraryDetails)
        {
            if (ModelState.IsValid)
            {
                List<ItineraryViewModel> itineraries = new List<ItineraryViewModel>();
                itineraries=    itineraryDetails.itineraryViewModels;
                List<Itinerary> itineraryList = new List<Itinerary>();
                foreach (ItineraryViewModel item in itineraries)
                {
                    string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
                    string extension = Path.GetExtension(item.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    item.ImageSource = "~/Images/ItineraryImages/" + fileName;
                    Itinerary itineraryDetail = AutoMapper.Mapper.Map<ItineraryViewModel, Itinerary>(item);
                    fileName = Path.Combine(Server.MapPath("~/Images/ItineraryImages/"), fileName);
                    item.ImageFile.SaveAs(fileName);
                    itineraryList.Add(itineraryDetail);
                }
                itineraryBL.AddItinerary(itineraryList);
                return RedirectToAction("ViewPackage", "Package");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Itinerary itinerary = itineraryBL.GetItineraryById(id);
            ItineraryViewModel itineraryViewModel = AutoMapper.Mapper.Map<Itinerary, ItineraryViewModel>(itinerary);
            return View(itineraryViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "ItineraryId,PackageId,HotelName,HotelLocation,SightSeeing,Meal,DayName,ImageSource,ImageFile,DetailedItinerary,Location")]ItineraryViewModel itineraryViewModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(itineraryViewModel.ImageFile.FileName);
            string extension = Path.GetExtension(itineraryViewModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            itineraryViewModel.ImageSource = "~/Images/ItineraryImages/" + fileName;
            Itinerary itinerary = AutoMapper.Mapper.Map<ItineraryViewModel, Itinerary>(itineraryViewModel);
            fileName = Path.Combine(Server.MapPath("~/Images/ItineraryImages/"), fileName);
            itineraryViewModel.ImageFile.SaveAs(fileName);
            itineraryBL.UpdateItinerary(itinerary);
            return RedirectToAction("ViewItinerary", new { id = itinerary.PackageId });
        }

        public ActionResult Delete(int id)
        {
            itineraryBL.DeleteItinerary(id);
            return View();
        }
    }
}