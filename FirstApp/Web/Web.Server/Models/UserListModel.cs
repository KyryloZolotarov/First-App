namespace Web.Server.Models
{
    public class UserListModel
    {
        public string UserId { get; set; }
        public List<ListModel> Lists { get; set; }
    }
}
