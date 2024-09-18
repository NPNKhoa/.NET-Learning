using ProductStore.Dtos.Category;
using ProductStore.Models;

namespace ProductStore.Dtos.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public String? ProductName { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
