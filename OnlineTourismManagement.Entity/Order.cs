using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    public class Order
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        [MaxLength(64)]
        public string UserMailId { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public int AdultsCount { get; set; }

        [Required]
        public int ChildrensCount { get; set; }

        [Required]
        public int MobileNumber { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int PackagePrice { get; set; }

        public Package Packages { get; set; }
    }
}
