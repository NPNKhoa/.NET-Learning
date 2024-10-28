using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string email_address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
