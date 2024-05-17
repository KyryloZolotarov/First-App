using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Controllers
{
    [Route("lists")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BoardListModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetListsAsync(int id)
        {
            var result = await _listService.GetListsAsync(id);
            return Ok(result.Lists);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddListAsync([FromBody] AddListRequest list)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            var listId = await _listService.AddListAsync(userId, list);
            return Ok(listId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteListAsync([FromBody] DeleteListRequest list)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            await _listService.DeleteListAsync(userId, list);
            return Ok();
        }

        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PatchListAsync(int id, [FromBody] JsonPatchDocument<UpdateListRequest> list)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            await _listService.PatchListAsync(userId, id, list);
            return Ok();
        }
    }
}
