using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    [Table("Package")]
    public class Package
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }

        [Required]
        public int PackageTypeId { get; set; }

        public PackageType PackageTypes { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(IsUnique =true)]
        public string PackageName { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int Availability { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime UpdationDate { get; set; }

        [Required]
        public string ImageSource { get; set; }

        [Required]
        public int PackagePrice { get; set; }



        //public Order Orders { get; set; }
    }
}
