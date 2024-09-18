using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMedicineBE.Models
{
    public class Medicines
    {
        [Key]
        public Guid ID { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Manufacturer { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpDate { get; set; }
        [MaxLength(100)]
        public string? ImageUrl { get; set; }
        public int Status { get; set; }

    }
}
