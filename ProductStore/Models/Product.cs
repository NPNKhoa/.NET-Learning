using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public String? ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Units in stock can not be a positive number")]
        public int UnitsInStock { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Product price must be a non-positive value")]
        public decimal UnitPrice { get; set; }
    }
}
