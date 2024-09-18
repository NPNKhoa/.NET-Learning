using FinShark.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol can not be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Symbol can not be over 100 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        [Range(0, 1000000000, ErrorMessage = "Purchase must be in range (0 and 1000000000)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(19,2)")]
        [Required]
        [Range(0.001, 100, ErrorMessage = "LastDiv must be in range (0.001 and 100)")]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Industry can not be over 100 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(0, 50000000000000, ErrorMessage = "Market Cap must be in range (0 and 50000000000000)")]
        public long MarketCap { get; set; }
    }
}
