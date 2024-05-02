

using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Web.Server.Data.Requests
{
    public class RecordRequest
    {
        public OperationType Event { get; set; }
        public string Property { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int CardId { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
