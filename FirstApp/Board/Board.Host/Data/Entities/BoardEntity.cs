using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Board.Host.Data.Entities
{
    public class BoardEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
    }
}
