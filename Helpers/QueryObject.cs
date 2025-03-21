namespace AvtoElon.API.Demo.Helpers
{
    public class QueryObject
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public long Price { get; set; }
        public string SortBy { get; set; } = string.Empty;
        public bool isDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
