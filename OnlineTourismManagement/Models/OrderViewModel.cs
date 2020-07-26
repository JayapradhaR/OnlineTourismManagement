using OnlineTourismManagement.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineTourismManagement.Models
{
    public class OrderViewModel
    {
        [Display(Name="Booking Id")]
        public int BookingId { get; set; }

        [Display(Name ="Mail Id")]
        [Required(ErrorMessage ="User mail id required")]
        public string UserMailId { get; set; }

        [Display(Name ="From")]
        [Required(ErrorMessage ="Frome Date required")]
        public DateTime FromDate { get; set; }

        [Display(Name ="To")]
        [Required(ErrorMessage ="To date required")]
        public DateTime ToDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Display(Name ="Adults")]
        [Required(ErrorMessage ="Adults count")]
        public int AdultsCount { get; set; }

        [Display(Name ="Childrens")]
        [Required]
        public int ChildrensCount { get; set; }

        [Display(Name ="Mobile Number")]
        [Required(ErrorMessage ="Mobile Number required")]
        public int MobileNumber { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int PackagePrice { get; set; }

        public Package Packages { get; set; }
    }
}