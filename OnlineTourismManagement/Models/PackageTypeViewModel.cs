using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OnlineTourismManagement.Models
{
    public class PackageTypeViewModel
    { 
        public int PackageTypeId { get; set; }

        [Required(ErrorMessage ="Package type required")]
        [Display(Name ="Package Type")]
        public string PackageTypeName { get; set; }

        [Display(Name = "Image Source")]
        public string ImageSource { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}