using Infrastructure.Enums;

namespace Web.Server.Data.Requests
{
    public class UpdateCardRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int ListId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
