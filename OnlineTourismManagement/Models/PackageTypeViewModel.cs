using System.ComponentModel.DataAnnotations;

namespace OnlineTourismManagement.Models
{
    public class PackageTypeViewModel
    { 
        public int PackageTypeId { get; set; }

        [Required(ErrorMessage ="Package type required")]
        [Display(Name ="Package Type")]
        public string PackageTypeName { get; set; }

    }
}