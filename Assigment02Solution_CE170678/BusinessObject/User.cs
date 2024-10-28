using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        [Required]
        [EmailAddress]
        public string email_address { get; set; }
        [Required]
        public string password { get; set; }
        public string? source { get; set; }
        public string? first_name { get; set; }
        public string? middle_name { get; set; }
        public string? last_name { get; set; }
        public DateTime hire_date { get; set; }

        [ForeignKey("Role")]
        public int role_id { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("Publisher")]
        public int? pub_id { get; set; }
        public Publisher? Publisher { get; set; }

    }
}
