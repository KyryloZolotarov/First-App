using History.Host.Models.Dtos;
using History.Host.Models.Requests;
using History.Host.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace History.Host.Controllers
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RecordDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRecords([FromBody] string userId)
        {
            var result = await _historyService.GetRecordsAsync(userId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddRecord([FromBody] RecordRequest record)
        {
            await _historyService.AddRecordAsync(record);
            return Ok();
        }
    }
}
