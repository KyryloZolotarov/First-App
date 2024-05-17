namespace Web.Server.Data.Models
{
    public class BoardListModel
    {
        public int? BoardId { get; set; }
        public List<ListModel> Lists { get; set; }
    }
}
