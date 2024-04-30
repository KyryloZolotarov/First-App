using List.Host.Models.Dtos;
using List.Host.Models.Requests;
using List.Host.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace List.Host.Controllers
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLists([FromBody] string userId)
        {
            var result = await _listService.GetListsAsync(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ListDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetList(int id)
        {
            var result = await _listService.GetListAsync(id);
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
        public async Task<IActionResult> UpdateList(int id, [FromBody] ListRequest list)
        {
            await _listService.UpdateListAsync(id, list);
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
