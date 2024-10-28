using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class BookAuthor
    {
        [Key]
        public int author_id { get; set; }
        public virtual Author? Author { get; set; }

        [Key]
        public int book_id { get; set; }
        public virtual Book? Book { get; set; }

        public int author_order { get; set; }
        public decimal royalty_percentage { get; set; }
    }
}
