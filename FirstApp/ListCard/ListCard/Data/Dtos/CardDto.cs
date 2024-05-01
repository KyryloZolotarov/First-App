using Infrastructure.Enums;

namespace ListCard.Data.Dtos
{
    public class CardDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int ListId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
