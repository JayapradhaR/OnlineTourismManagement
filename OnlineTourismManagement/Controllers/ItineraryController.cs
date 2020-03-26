using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;

namespace OnlineTourismManagement.Controllers
{
    public class ItineraryController : Controller
    {
        IItineraryBL itinerary;
        public ItineraryController()
        {
            itinerary = new ItineraryBL();
        }
        // GET: Itinerary
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AddItinerary(int id, int duration)
        {
            ItineraryViewModels itineraryViewModels = new ItineraryViewModels();
            itineraryViewModels.Duration = duration;
            TempData["Duration"] = duration;
            return View();
        }
        [HttpPost]
        public ActionResult AddItinerary(ItineraryViewModels itineraryDetails)
        {
            if (ModelState.IsValid)
            {
                //List<Itinerary> itineraries = AutoMapper.Mapper.Map<List<ItineraryViewModels>, List<Itinerary>>(itineraryDetails);
                //itinerary.AddItinerary(itineraries);
                return RedirectToAction("ViewPackage", "Package");
            }
            return View();
        }
    }
}