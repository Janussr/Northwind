using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(40)]
        public string? ProductName { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [MaxLength(20)]
        public string? QuantityPerUnit { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Required]
        public short UnitsInStock { get; set; }

        [Required]
        public short UnitsOnOrder { get; set; }

        [Required]
        public short ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }

        // Navigation properties
        public Supplier Supplier { get; set; }

        public Category Category { get; set; }
    }
}
