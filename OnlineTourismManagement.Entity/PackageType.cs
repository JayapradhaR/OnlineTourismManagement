using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    public class PackageType
    {
        [Key]
        [Required]
        public int PackageTypeId { get; set; }

        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string PackageTypeName { get; set; }

        [Required]
        public string ImageSource { get; set; }

        public ICollection<Package> packages { get; set; }
    }
}
