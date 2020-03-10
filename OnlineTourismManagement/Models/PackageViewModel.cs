using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTourismManagement.Models
{
    public class PackageViewModel
    {
        [Display(Name ="Package Id")]
        public int PackageId { get; set; }

        [Required(ErrorMessage ="Package name required")]
        [Display(Name = "Package Name")]
        public string PackageName { get; set; }

        [Required(ErrorMessage ="Package price required")]
        [Display(Name = "Package Price")]
        public int PackagePrice { get; set; }

        [Required(ErrorMessage ="Duration required")]
        [Display(Name ="Duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Availability count required")]
        [Display(Name = "Availability")]
        public int Availability { get; set; }

        [Display(Name ="Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name ="Updation Date")]
        public DateTime UpdationDate { get; set; }
    }
}