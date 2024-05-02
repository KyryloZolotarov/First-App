using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Web.Server.Data.Dtos
{
    public class RecordDto
    {
        public int Id { get; set; }
        public OperationType Event { get; set; }
        public string Property { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int cardId { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
