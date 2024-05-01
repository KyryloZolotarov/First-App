using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Server.Services.Interfaces;

namespace Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }
    }
}
