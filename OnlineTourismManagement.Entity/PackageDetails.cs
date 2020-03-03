using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    [Table("Package")]
    public class PackageDetails
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }

        [Required]
        [MaxLength(30)]
        [Index(IsUnique =true)]
        public string PackageName { get; set; }

        [Required]
        [MaxLength(30)]
        public string PackageType { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime UpdationDate { get; set; }

        [Required]
        public int PackagePrice { get; set; }
    }
}
