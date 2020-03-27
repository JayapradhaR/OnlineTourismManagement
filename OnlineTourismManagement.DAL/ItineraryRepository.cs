using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public interface IItinerary
    {
        IEnumerable<Itinerary> GetItineraries();
        void AddItinerary(List<Itinerary> itineraries);
        Itinerary GetItineraryById(int itineraryid);
        void UpdateItinerary(Itinerary itinerary);
        IEnumerable<Itinerary> GetItineraryByPackage(int packageId);
        void DeleteItinerary(int id);
    }
    /// <summary>
    /// This ItineraryRepository performs CRUD operations for itinerary
    /// </summary>
    public class ItineraryRepository : IItinerary
    {
        //Get itinerary details
        public IEnumerable<Itinerary> GetItineraries()
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Itineraries.Include("Packages").ToList();
            }
        }
        //Adding itinerary details in database
        public void AddItinerary(List<Itinerary> itineraries)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Itineraries.AddRange(itineraries);
                context.SaveChanges();
            }
        }
        //Get itinerary by itinerary id
        public Itinerary GetItineraryById(int itineraryid)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                return context.Itineraries.Where(id => id.ItineraryId == itineraryid).SingleOrDefault();
            }
        }
        //Update itinerary details
        public void UpdateItinerary(Itinerary itinerary)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Entry(itinerary).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Get itinerary by package
        public IEnumerable<Itinerary> GetItineraryByPackage(int packageId)
        {
           using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                return context.Itineraries.Include("Packages").Where(id => id.PackageId == packageId).ToList();
            }
        }
        //Delete itinerary details
        public void DeleteItinerary(int id)
        {
            using(OnlineTourismDBContext context=new OnlineTourismDBContext())
            {
                Itinerary itinerary = GetItineraryById(id);
                context.Itineraries.Attach(itinerary);
                context.Itineraries.Remove(itinerary); //Removing itineray details from database
                context.SaveChanges();
            }
        }
    }
}

