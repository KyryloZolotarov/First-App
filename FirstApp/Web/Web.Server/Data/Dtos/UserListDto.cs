namespace Web.Server.Repositories.Interfaces
{
    public class UserListDto
    {
        public string UserId { get; set; }
        public List<ListDto> Lists { get; set; }
    }
}
