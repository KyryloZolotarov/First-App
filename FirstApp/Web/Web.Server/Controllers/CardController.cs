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
    [Route("cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CardModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCardAsync(int id)
        {
            return Ok(await _cardService.GetCardAsync(id));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddCardAsync([FromBody] AddCardRequest card)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            await _cardService.AddCardAsync(userId, card);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCardAsync([FromBody] DeleteCardRequest card)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            await _cardService.DeleteCardAsync(userId, card);
            return Ok();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PatchCardAsync(int id, [FromBody] JsonPatchDocument<UpdateCardRequest> card)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
            await _cardService.PatchCardAsync(id, userId, card);
            return Ok();
        }
    }
}
