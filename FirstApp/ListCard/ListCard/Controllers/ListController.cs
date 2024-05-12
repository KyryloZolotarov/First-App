using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ListCard.Controllers
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
        [ProducesResponseType(typeof(BoardListDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetListByBoard([FromBody] int id)
        {
            var result = await _listService.GetListsAsync(id);
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
        public async Task<IActionResult> PatchCard(int id, [FromBody] JsonPatchDocument<UpdateListRequest> list)
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
