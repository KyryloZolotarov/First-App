using List.Host.Models.Dtos;
using List.Host.Models.Requests;
using List.Host.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace List.Host.Controllers
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLists([FromBody] int boardId)
        {
            var result = await _listService.GetListsAsync(boardId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddList([FromBody] AddListRequest list)
        {
            var listId = await _listService.AddListAsync(list);
            return Ok(listId);
        }

        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PatchList(int id, [FromBody] JsonPatchDocument<UpdateListRequest> list)
        {
            await _listService.PatchListAsync(id, list);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteList(int id)
        {
            await _listService.DeleteListAsync(id);
            return Ok();
        }
    }
}
