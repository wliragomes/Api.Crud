namespace Application.DTOs
{
    public class PaginationResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public List<T> Data { get; set; }
    }
}
