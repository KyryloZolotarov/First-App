﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Data.Responses;
using Web.Server.Services.Interfaces;

namespace Web.Server.Controllers
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

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedRecordsResponse<RecordModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCardRecordsAsync(PaginatedRecordsRequest<int> param)
        {
            return Ok(await _historyService.GetCardRecordsAsync(param));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedRecordsResponse<RecordModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetÚserRecordsAsync(int pageSize, int pageIndex)
        {
            var param = new PaginatedRecordsRequest<string>();
            param.PageSize = pageSize;
            param.PageIndex = pageIndex;
            param.Id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            return Ok(await _historyService.GetUserRecordsAsync(param));
        }
    }
}