namespace Web.Server.Data.Responses
{
    public class PaginatedRecordsResponse<T>
        where T : notnull
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
        public List<T> Records { get; set; }
    }
}
