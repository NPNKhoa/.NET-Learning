using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Role
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int role_id { get; set; }
        [Required]
        public string role_desc { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
