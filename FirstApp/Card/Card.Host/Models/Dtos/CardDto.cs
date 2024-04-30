using Card.Host.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Card.Host.Models.Dtos
{
    public class CardDto
    {
        public class CardEntity
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Priority Priority { get; set; }
            public int ListId { get; set; }
            public DateTime DueDate { get; set; }
        }
    }
}
