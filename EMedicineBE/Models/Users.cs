using System.ComponentModel.DataAnnotations;

namespace EMedicineBE.Models
{
    public class Users
    {
        [Key]
        public Guid ID { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        public string? Password { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        public decimal Fund { get; set; }
        [MaxLength(100)]
        public string? Type { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
