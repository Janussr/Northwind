using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class CustomerDemographic
    {
        [Key]
        public string CustomerTypeId { get; set; }

        public string CustomerDesc { get; set; }
    }
}
