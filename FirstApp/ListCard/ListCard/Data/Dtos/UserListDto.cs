namespace ListCard.Data.Dtos
{
    public class UserListDto
    {
        public string UserId { get; set; }
        public List<ListDto> Lists { get; set; }
    }
}
