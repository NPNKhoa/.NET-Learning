using System.ComponentModel.DataAnnotations;

namespace ProductStore.Dtos.Product
{
    public class ProductCreateUpdateDto
    {
        [Required]
        [StringLength(100)]
        public String? ProductName { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Units in stock can not be a positive number")]
        public int UnitsInStock { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Product price must be a non-positive value")]
        public decimal UnitPrice { get; set; }
    }
}
