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
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        //[Required]
        //public DateTime ToDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public int AdultsCount { get; set; }

        [Required]
        public int ChildrensCount { get; set; }

        [Required]
        public long MobileNumber { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int PackagePrice { get; set; }
       
        [ForeignKey("PackageId")]
        public virtual Package Packages { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Customer Customer { get; set; }
    }
}
