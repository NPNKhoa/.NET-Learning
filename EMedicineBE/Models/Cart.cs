using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMedicineBE.Models
{
    public class Cart
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("UserId")]
        public Users? user { get; set; }
    }
}
