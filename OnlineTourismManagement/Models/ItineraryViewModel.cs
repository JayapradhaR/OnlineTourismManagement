using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTourismManagement.Models
{

    public class ItineraryViewModels
    {
        public int Duration { get; set; }

        public List<ItineraryViewModel> itineraryViewModels { get; set; }
    }
    public class ItineraryViewModel
    {
        public int PackageId { get; set; }

        public int Id { get; set; }

        public string DayName { get; set; }

        public string HotelName { get; set; }


        public string SightSeeing { get; set; }


        public string Meal { get; set; }


    }
}