namespace Web.Server.Data.Models
{
    public class UserListModel
    {
        public string UserId { get; set; }
        public List<ListModel> Lists { get; set; }
    }
}
