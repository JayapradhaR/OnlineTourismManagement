using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;

namespace OnlineTourismManagement.Controllers
{
    public class ItineraryController : Controller
    {
        IItineraryBL itineraryBL;
        public ItineraryController()
        {
            itineraryBL = new ItineraryBL();
        }
        // GET: Itinerary
        public ViewResult Index()
        {
            return View();
        }
        //Viewing itinerary details
        public ActionResult ViewItinerary(int id)
        {
            IEnumerable<Itinerary> itineraries = itineraryBL.GetItineraryByPackage(id);
            return View(itineraries);
        }
        [HttpGet]
        public ViewResult AddItinerary(int id, int duration)
        {
            TempData["Id"] = id;
            TempData["Duration"] = duration;
            return View();
        }
        [HttpPost]
        public ActionResult AddItinerary(ItineraryViewModels itineraryDetails)
        {
            if (ModelState.IsValid)
            {
                List<ItineraryViewModel> itineraries = itineraryDetails.itineraryViewModels;
                List<Itinerary> itineraryList = new List<Itinerary>();
                foreach (ItineraryViewModel item in itineraries)
                {
                    Itinerary itineraryDetail = AutoMapper.Mapper.Map<ItineraryViewModel, Itinerary>(item);
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
        public ActionResult Update([Bind(Include = "ItineraryId,PackageId,HotelName,HotelLocation,SightSeeing,Meal,DayName")]ItineraryViewModel itineraryViewModel)
        {
            Itinerary itinerary = AutoMapper.Mapper.Map<ItineraryViewModel, Itinerary>(itineraryViewModel);
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