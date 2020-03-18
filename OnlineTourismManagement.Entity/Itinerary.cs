using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    public class Itinerary
    {
        public int PackageId { get; set; }

        
        public Package Package { get; set; }

        [Key]
        [Required]
        public int ItineraryId { get; set; }

        [Required]
        public int DayName { get; set; }

        [Required]
        [MaxLength(30)]
        public string HotelName { get; set; }

        [Required]
        [MaxLength(30)]
        public string SightSeeing { get; set; }

        [Required]
        [MaxLength(20)]
        public string Meal { get; set; }

    }
}
