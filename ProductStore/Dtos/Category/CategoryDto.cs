using ProductStore.Dtos.Product;

namespace ProductStore.Dtos.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
