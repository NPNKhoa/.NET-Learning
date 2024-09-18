namespace ProductManagementAPI.Dtos
{
    public class CreateUpdateProductDto
    {
        public String? ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
