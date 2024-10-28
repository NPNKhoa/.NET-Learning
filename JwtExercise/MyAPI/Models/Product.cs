using System;
using System.Collections.Generic;

namespace MyAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string Category { get; set; } = null!;

    public string Color { get; set; } = null!;

    public decimal? UnitPrice { get; set; }

    public int? AvailableQuantity { get; set; }
}
