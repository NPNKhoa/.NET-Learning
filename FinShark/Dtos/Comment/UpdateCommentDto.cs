using System.ComponentModel.DataAnnotations;

namespace FinShark.Dtos.Comment
{
    public class UpdateCommentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be at least 1 character and can not be over 300 character")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Content must be at least 1 character and can not be over 300 character")]
        public string Content { get; set; } = string.Empty;
    }
}
