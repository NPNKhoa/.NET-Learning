using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMedicineBE.Models
{
    public class OrderItems
    {
        [Key]
        public Guid ID { get; set; }
        public Guid OrderId { get; set; }
        public Guid MedicineId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("OrderId")]
        public Orders? order { get; set; }

        [ForeignKey("MedicineId")]
        public Medicines? medicine { get; set; }
    }
}
