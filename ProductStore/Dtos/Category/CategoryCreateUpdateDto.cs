using System.ComponentModel.DataAnnotations;

namespace ProductStore.Dtos.Category
{
    public class CategoryCreateUpdateDto
    {
        [Required]
        [StringLength(100)]
        public String? CategoryName { get; set; }
    }
}
