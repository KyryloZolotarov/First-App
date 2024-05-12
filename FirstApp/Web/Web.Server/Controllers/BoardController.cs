using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Services.Interfaces;

namespace Web.Server.Controllers
{
    [Route("boards")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<BoardModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBoardsAsync()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            return Ok(await _boardService.GetBoardsAsync(userId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBoardAsync([FromBody] AddBoardRequest board)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            var boardId = await _boardService.AddBoardAsync(userId, board);
            return Ok(boardId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBoardAsync([FromBody] DeleteBoardRequest board)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            await _boardService.DeleteBoardAsync(userId, board);
            return Ok();
        }

        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PatchListAsync(int id, [FromBody] JsonPatchDocument<UpdateBoardRequest> board)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            await _boardService.PatchBoardAsync(userId, id, board);
            return Ok();
        }
    }
}
