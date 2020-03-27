using OnlineTourismManagement.DAL;
using OnlineTourismManagement.Entity;
using System.Collections.Generic;

namespace OnlineTourismManagement.BL
{
    public interface IItineraryBL
    {
        IEnumerable<Itinerary> GetItineraries();
        void AddItinerary(List<Itinerary> itineraries);
        Itinerary GetItineraryById(int itineraryid);
        void UpdateItinerary(Itinerary itinerary);
        IEnumerable<Itinerary> GetItineraryByPackage(int packageId);
        void DeleteItinerary(int id);
    }
    public class ItineraryBL : IItineraryBL
    {
        IItinerary itineraryDAL;
        public ItineraryBL()
        {
            itineraryDAL = new ItineraryRepository();
        }
        public void AddItinerary(List<Itinerary> itineraries)
        {
            itineraryDAL.AddItinerary(itineraries); //Call AddItinerary() to add itinerary details
        }

        public void DeleteItinerary(int id)
        {
            itineraryDAL.DeleteItinerary(id); // Call DeleteItinerary() to delete itinerary details
        }

        public IEnumerable<Itinerary> GetItineraries()
        {
            return itineraryDAL.GetItineraries(); //Getting itinerary details
        }

        public Itinerary GetItineraryById(int itineraryid)
        {
            return itineraryDAL.GetItineraryById(itineraryid); // Getting itinerary details by itinerary id
        }

        public IEnumerable<Itinerary> GetItineraryByPackage(int packageId)
        {
            return itineraryDAL.GetItineraryByPackage(packageId); //Getting itinerary details by package id
        }

        public void UpdateItinerary(Itinerary itineraryDetails)
        {
            itineraryDAL.UpdateItinerary(itineraryDetails); //Update itinerary details
        }
    }
}
