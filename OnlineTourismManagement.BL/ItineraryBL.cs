using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.BL
{
    public interface IItineraryBL
    {
        IEnumerable<Itinerary> GetItineraries();
        void AddItinerary(List<Itinerary> itineraries);
        Itinerary GetItineraryById(int itineraryid);
        void UpdateItinerary(Itinerary itinerary);
    }
    public class ItineraryBL : IItineraryBL
    {
        IItinerary itinerary;
        public ItineraryBL()
        {
            itinerary = new ItineraryRepository();
        }
        public void AddItinerary(List<Itinerary> itineraries)
        {
            itinerary.AddItinerary(itineraries);
        }

        public IEnumerable<Itinerary> GetItineraries()
        {
            return itinerary.GetItineraries();
        }

        public Itinerary GetItineraryById(int itineraryid)
        {
            return itinerary.GetItineraryById(itineraryid);
        }

        public void UpdateItinerary(Itinerary itinerary)
        {
            
        }
    }
}
