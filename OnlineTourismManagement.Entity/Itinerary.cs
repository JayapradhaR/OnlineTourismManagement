using System.ComponentModel.DataAnnotations;

namespace OnlineTourismManagement.Entity
{
    public class Itinerary
    { 
        [Key]
        [Required]
        public int ItineraryId { get; set; }

        [Required]
        public int PackageId { get; set; }

        public Package Packages { get; set; }

        [Required]
        public int DayName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [Required]
        [MaxLength(30)]
        public string HotelName { get; set; }

        [Required]
        [MaxLength(50)]
        public string HotelLocation { get; set; }

        [Required]
        [MaxLength(30)]
        public string SightSeeing { get; set; }

        [Required]
        [MaxLength(20)]
        public string Meal { get; set; }

        [Required]
        public string ImageSource { get; set; }

        [Required]
        [MaxLength(200)]
        public string DetailedItinerary { get; set; }
    }
}
