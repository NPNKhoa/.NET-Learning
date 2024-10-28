using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class Book
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int book_id { get; set; }
        [Required]
        public string title { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public decimal advance { get; set; }
        public decimal royalty { get; set; }
        public int ytd_sales { get; set; }
        public string notes { get; set; }
        public DateTime published_date { get; set; }

        [ForeignKey("Publisher")]
        public int pub_id { get; set; }
        public virtual Publisher? Publisher { get; set; }

        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
