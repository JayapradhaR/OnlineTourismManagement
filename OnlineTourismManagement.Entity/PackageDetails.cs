using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineTourismManagement.Entity
{
    public class PackageDetails
    {
        [Key]
        [Required]
        [Display(Name="Package Id")]
        public int PackageId { get; set; }

        [Required]
        [Display(Name = "Package Name")]
        public string PackageName { get; set; }

        [Required]
        [Display(Name="Package Type")]
        public string PackageType { get; set; }

        [Required]
        [Display(Name="Creation Date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(Name="Updation Date")]
        public DateTime UpdationDate { get; set; }

        [Required]
        [Display(Name="Package Price")]
        public int PackagePrice { get; set; }
           

    }
}
