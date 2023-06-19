using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class Territory
    {
        [Key]
        [MaxLength(20)]
        public string TerritoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TerritoryDescription { get; set; }

        [Required]
        public int RegionId { get; set; }

        // Navigation property
        public Region Region { get; set; }

        // Navigation property
        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
