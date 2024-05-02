using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ListCard.Controllers
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
        [ProducesResponseType(typeof(CardDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCard(int id)
        {
            var result = await _cardService.GetCardAsync(id);
            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddCard([FromBody] AddCardRequest card)
        {
            await _cardService.AddCardAsync(card);
            return Ok();
        }


        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> PatchCard(int id, [FromBody] JsonPatchDocument<UpdateCardRequest> card)
        {
            await _cardService.PatchCardAsync(id, card);
            return Ok();
        }
        

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCard(int id)
        {
            await _cardService.DeleteCardAsync(id);
            return Ok();
        }
    }
}
