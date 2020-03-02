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

        [Required(ErrorMessage ="Package type required")]
        [Display(Name = "Package Type")]
        public string PackageType { get; set; }

        [Required(ErrorMessage ="Package price required")]
        [Display(Name = "Package Price")]
        public int PackagePrice { get; set; }

        [Display(Name ="Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name ="Updation Date")]
        public DateTime UpdationDate { get; set; }
    }
}