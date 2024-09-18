namespace FinShark.Helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? OrderBy { get; set; } = String.Empty;
        public bool IsDescending { get; set; } = false;
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 2;
    }
}
