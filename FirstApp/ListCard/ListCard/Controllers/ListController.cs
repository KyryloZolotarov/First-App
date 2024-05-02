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
        [ProducesResponseType(typeof(UserListDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetListByUser([FromBody] string id)
        {
            var result = await _listService.GetListsAsync(id);
            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddList([FromBody] AddListRequest list)
        {
            await _listService.AddListAsync(list);
            return Ok();
        }


        [HttpPatch("{id}")]
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
