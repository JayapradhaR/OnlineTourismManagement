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
        
        [Display(Name="Name")]
        [Required(ErrorMessage ="Name required")]
        public string Name { get; set; }

        [Display(Name ="Departure Date")]
        [Required(ErrorMessage ="Frome Date required")]
        public DateTime FromDate { get; set; }

        //[Display(Name ="To")]
        //[Required(ErrorMessage ="To date required")]
        //public DateTime ToDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Display(Name ="Adults")]
        [Required(ErrorMessage ="Adults count")]
        public int AdultsCount { get; set; }

        [Display(Name ="Childrens")]
        [Required]
        public int ChildrensCount { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter valid phone number")]

        public long MobileNumber { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int PackagePrice { get; set; }

        public Package Packages { get; set; }

        [Required]
        public int UserId { get; set; }

        public Customer Account { get; set; }
    }
}