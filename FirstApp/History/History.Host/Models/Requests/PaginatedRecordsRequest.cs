namespace History.Host.Models.Requests
{
    public class PaginatedRecordsRequest<T>
        where T : notnull
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        public T Id { get; set; }
    }
}
