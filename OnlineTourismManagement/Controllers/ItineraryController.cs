using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTourismManagement.BL;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;

namespace OnlineTourismManagement.Controllers
{
    public class ItineraryController : Controller
    {
        // GET: Itinerary
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddItinerary(int id, int duration)
        {
            ItineraryViewModels itineraryViewModels = new ItineraryViewModels();
            itineraryViewModels.Duration = duration;
            TempData["Duration"] = duration;
            return View();
        }
        [HttpPost]
        public ActionResult AddItinerary(List<ItineraryViewModels> itinerary)
        {
            //TempData["Duration"] = itinerary.Duration;
            List<Itinerary> itineraries = AutoMapper.Mapper.Map<List<ItineraryViewModels>, List<Itinerary>>(itinerary);
            PackageBL.AddItinerary(itineraries);
            return View("Index");
        }
    }
}