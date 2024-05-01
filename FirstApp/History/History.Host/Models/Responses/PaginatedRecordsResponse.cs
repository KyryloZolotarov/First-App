namespace History.Host.Models.Responses
{
    public class PaginatedRecordsResponse<T>
    where T : notnull
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T> Records { get; set; }
    }
}
