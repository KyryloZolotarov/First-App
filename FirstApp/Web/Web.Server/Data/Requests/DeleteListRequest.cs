namespace Web.Server.Data.Requests
{
    public class DeleteListRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? BoardId { get; set; }
    }
}
