using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTourismManagement.Models
{
    public class PackageViewModel
    {
        [Required(ErrorMessage ="Package name required")]
        [Display(Name = "Package Name")]
        public string PackageName { get; set; }

        [Required(ErrorMessage ="Package type required")]
        [Display(Name = "Package Type")]
        public string PackageType { get; set; }

        [Required(ErrorMessage ="Package price required")]
        [Display(Name = "Package Price")]
        public int PackagePrice { get; set; }
    }
}