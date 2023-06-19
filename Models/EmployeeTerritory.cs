using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public class EmployeeTerritory
    {
        [Key]
        [Column(Order = 0)]
        public int EmployeeId { get; set; }

        [Key]
        [Column(Order = 1)]
        [MaxLength(20)]
        public string TerritoryId { get; set; }
    }
}
