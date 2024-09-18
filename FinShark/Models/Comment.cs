using System.ComponentModel.DataAnnotations;

namespace FinShark.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Title must be at least 1 character")]
        [MaxLength(100, ErrorMessage = "Title can not be over 100 character")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Content must be at least 1 character")]
        [MaxLength(300, ErrorMessage = "Content can not be over 300 character")]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
    }
}
