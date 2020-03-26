using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public interface IItinerary
    {
        IEnumerable<Itinerary> GetItineraries();
        void AddItinerary(List<Itinerary> itineraries);
        Itinerary GetItineraryById(int itineraryid);
        void UpdateItinerary(Itinerary itinerary);
    }
    public class ItineraryRepository : IItinerary
    {
        public IEnumerable<Itinerary> GetItineraries()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Itineraries.ToList();
            }
        }
        public void AddItinerary(List<Itinerary> itineraries)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Itineraries.AddRange(itineraries);
                context.SaveChanges();
            }
        }
        public Itinerary GetItineraryById(int itineraryid)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Itineraries.Where(id => id.ItineraryId == itineraryid).SingleOrDefault();
            }
        }
        public void UpdateItinerary(Itinerary itinerary)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {

            }
        }
    }
}

