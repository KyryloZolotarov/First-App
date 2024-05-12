using Board.Host.Models.Dtos;
using Board.Host.Models.Requests;
using Board.Host.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Board.Host.Controllers
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BoardDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBoards([FromBody] string userId)
        {
            var result = await _boardService.GetBoardsAsync(userId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBoard([FromBody] AddBoardRequest board)
        {
            var boardId = await _boardService.AddBoardAsync(board);
            return Ok(boardId);
        }

        [HttpPatch("{id}")]
        [Consumes("application/json-patch+json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PatchBoard(int id, [FromBody] JsonPatchDocument<UpdateBoardRequest> board)
        {
            await _boardService.PatchBoardAsync(id, board);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            await _boardService.DeleteBoardAsync(id);
            return Ok();
        }
    }
}
