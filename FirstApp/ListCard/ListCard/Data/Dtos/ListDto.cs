namespace ListCard.Data.Dtos
{
    public class ListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public List<CardDto> Cards { get; set; }
    }
}
