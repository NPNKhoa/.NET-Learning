using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Customer
    {
        [Key]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullname { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

    }
}
