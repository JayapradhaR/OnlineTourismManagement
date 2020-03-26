using OnlineTourismManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int ItineraryId { get; set; }

        [Required]
        public string DayName { get; set; }

        [Required(ErrorMessage = "Hotel name required")]
        public string HotelName { get; set; }

        [Required(ErrorMessage = "Sight seeing details required")]
        public string SightSeeing { get; set; }

        [Required(ErrorMessage = "Meal details required")]
        public string Meal { get; set; }
    }
}