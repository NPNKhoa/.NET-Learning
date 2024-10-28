namespace BusinessObject.DTOs
{
    public class CreateBookDto
    {
        public string title { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public decimal advance { get; set; }
        public decimal royalty { get; set; }
        public int ytd_sales { get; set; }
        public string notes { get; set; }
        public DateTime published_date { get; set; }
        public int pub_id { get; set; }
    }
}
