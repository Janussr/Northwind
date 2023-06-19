using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    [Table("CustomerCustomerDemo")]
    public class CustomerCustomerDemo
    {
        [Key]
        [Column("CustomerID", Order = 0)]
        public string CustomerId { get; set; }

        [Key]
        [Column("CustomerTypeID", Order = 1)]
        public string CustomerTypeId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("CustomerTypeId")]
        public CustomerDemographic CustomerDemographic { get; set; }
    }
}
