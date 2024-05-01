using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ListDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetList(int id)
        {
            var result = await _listService.GetListAsync(id);
            return Ok(result);
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
        public async Task<IActionResult> AddList([FromBody] ListRequest list)
        {
            await _listService.AddListAsync(list);
            return Ok();
        }


        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PatchCard(int id, [FromBody] ListRequest list)
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
