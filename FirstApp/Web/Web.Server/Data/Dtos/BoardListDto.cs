namespace Web.Server.Repositories.Interfaces
{
    public class BoardListDto
    {
        public int? BoardId { get; set; }
        public List<ListDto> Lists { get; set; }
    }
}
