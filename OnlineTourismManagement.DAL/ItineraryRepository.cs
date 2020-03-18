using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OnlineTourismManagement.DAL
{
    public class ItineraryRepository
    {
        //     public static IEnumerable<Itinerary> GetItineraries()
        //     {
        //         using(OnlineTourismDBContext context=new OnlineTourismDBContext())
        //         {
        //             //return context.Itineraries.ToList();
        //         }
        //     }
        public static void AddItinerary(List<Itinerary> itineraries)
        {
            using (OnlineTourismDBContext context = new OnlineTourismDBContext())
            {
                context.Itineraries.AddRange(itineraries);
                context.SaveChanges();
            }
        }
        //     public static Itinerary GetItineraryById(int itineraryid)
        //     {
        //         using(OnlineTourismDBContext context=new OnlineTourismDBContext())
        //         {
        //             //return context.Itineraries.Where(id => id.Id == itineraryid).SingleOrDefault();
        //         }
        //     }
        //     public static void UpdateItinerary(Itinerary itinerary)
        //     {
        //         using(OnlineTourismDBContext context=new OnlineTourismDBContext())
        //         {

        //         }
        //     }
        // }
    }
}
