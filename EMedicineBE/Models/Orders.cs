using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMedicineBE.Models
{
    public class Orders
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string? OrderNo { get; set; }
        public decimal OrdersTotal { get; set; }
        [MaxLength(100)]
        public string? OrderStatus { get; set; }

        [ForeignKey("UserId")]
        public Users? user { get; set; }
    }
}
