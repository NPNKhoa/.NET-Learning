using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(18, 65)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
