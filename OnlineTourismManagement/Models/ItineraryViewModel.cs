using OnlineTourismManagement.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int ItineraryId { get; set; }

        public int PackageId { get; set; }

        public Package Packages { get; set; }

        public string DayName { get; set; }

        [Required(ErrorMessage = "Location Required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Hotel name required")]
        public string HotelName { get; set; }

        [Required(ErrorMessage ="Hotel location required")]
        public string HotelLocation { get; set; }

        [Required(ErrorMessage = "Sight seeing details required")]
        public string SightSeeing { get; set; }

        [Required(ErrorMessage = "Meal details required")]
        public string Meal { get; set; }

        [Display(Name ="Image Source")]
        public string ImageSource { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [Required(ErrorMessage ="Itinerary details required")]
        public string DetailedItinerary { get; set; }

    }
}