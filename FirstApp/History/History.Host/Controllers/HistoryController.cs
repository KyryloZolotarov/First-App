using History.Host.Models.Dtos;
using History.Host.Models.Requests;
using History.Host.Models.Responses;
using History.Host.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace History.Host.Controllers
{
    [Route("history")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("userRecords")]
        [ProducesResponseType(typeof(PaginatedRecordsResponse<RecordDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserRecords([FromBody] PaginatedRecordsRequest<string> param)
        {
            var result = await _historyService.GetUserRecordsAsync(param);
            return Ok(result);
        }

        [HttpGet("cardRecords")]
        [ProducesResponseType(typeof(PaginatedRecordsResponse<RecordDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCardRecords([FromBody] PaginatedRecordsRequest<int> param)
        {
            var result = await _historyService.GetCardRecordsAsync(param);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddRecord([FromBody] RecordRequest record)
        {
            await _historyService.AddRecordAsync(record);
            return Ok();
        }

        [HttpPost("list")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddRecords([FromBody] List<RecordRequest> records)
        {
            await _historyService.AddRecordsAsync(records);
            return Ok();
        }
    }
}
