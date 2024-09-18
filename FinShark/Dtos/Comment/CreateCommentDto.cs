using System.ComponentModel.DataAnnotations;

namespace FinShark.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be at least 1 character")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Content can not be over 300 character")]
        public string Content { get; set; } = string.Empty;
    }
}
