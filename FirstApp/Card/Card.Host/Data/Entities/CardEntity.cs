using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace Card.Host.Data.Entities
{
    public class CardEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int ListId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
