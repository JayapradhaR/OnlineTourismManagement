using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.Entity
{
    public class GiftCardOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GiftCardOrderId { get; set; }

        [Required]
        public int CardId { get; set; }

        [ForeignKey("CardId")]
        public GiftCard GiftCard { get; set; }

        [Required]
        public long Denomination { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string SenderName { get; set; }

        [Required]
        [MaxLength(64)]
        public string SenderMailId { get; set; }

        [Required]
        public long SenderMobileNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string ReceiverName { get; set; }

        [Required]
        [MaxLength(64)]
        public string ReceiverMailId { get; set; }

        [Required]
        [MaxLength(64)]
        public string ConfirmReceiverMailId { get; set; }

        [Required]
        public long ReceiverMobileNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string CardNumber { get; set; }

        [Required]
        public int PinNumber { get; set; }
    }
}
