using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Publisher
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pub_id { get; set; }
        [Required]
        public string publisher_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
