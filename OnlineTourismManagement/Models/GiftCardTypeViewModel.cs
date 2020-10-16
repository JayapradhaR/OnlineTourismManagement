using System.ComponentModel.DataAnnotations;
using System.Web;

namespace OnlineTourismManagement.Models
{
    public class GiftCardTypeViewModel
    {
        [Key]
        public int GiftCardTypeId { get; set; }

        [Required(ErrorMessage ="Gift Card type name required")]
        [Display(Name="Giftcard Type")]
        public string GiftCardTypeName { get; set; }

        [Display(Name="Image Source")]
        public string ImageSource { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}