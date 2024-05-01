using History.Host.Enums;

namespace History.Host.Models.Requests
{
    public class RecordRequest
    {
        public Events Event { get; set; }
        public string Property { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int cardId { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
