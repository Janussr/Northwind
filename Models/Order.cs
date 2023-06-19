using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [Required]
        public decimal Freight { get; set; }

        [Required]
        [MaxLength(40)]
        public string ShipName { get; set; }

        [Required]
        [MaxLength(60)]
        public string ShipAddress { get; set; }

        [Required]
        [MaxLength(15)]
        public string ShipCity { get; set; }

        [Required]
        [MaxLength(15)]
        public string ShipRegion { get; set; }

        [Required]
        [MaxLength(10)]
        public string ShipPostalCode { get; set; }

        [Required]
        [MaxLength(15)]
        public string ShipCountry { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
