using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTourismManagement.Entity
{
   public class PackageType
    {
        [Key]
        [Required]
        public int PackageTypeId { get; set; }

        [Required]
        [MaxLength(30)]
        public string PackageTypeName { get; set; }

        public ICollection<Package> packages { get; set; }
    }
}
