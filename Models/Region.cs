using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RegionDescription { get; set; }

        // Navigation property
        public ICollection<Territory> Territories { get; set; }
    }
}
