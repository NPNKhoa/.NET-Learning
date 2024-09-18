using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public String? CategoryName { get; set; }
        public List<Product>? Products { get; set; }
    }
}
