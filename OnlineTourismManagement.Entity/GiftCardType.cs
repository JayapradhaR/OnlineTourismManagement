using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    public class GiftCardType
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GiftCardTypeId { get; set; }

        [Required]
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string GiftCardTypeName { get; set; }

        [Required]
        public string ImageSource { get; set; }

    }
}
