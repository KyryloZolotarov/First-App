using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Server.Services.Interfaces;

namespace Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
    }
}
