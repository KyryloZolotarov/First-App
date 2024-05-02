using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;
using Card.Host.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Card.Host.Controllers
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CardDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCards([FromBody] int listId)
        {
            var result = await _cardService.GetCardsAsync(listId);
            return Ok(result);
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
        public async Task<IActionResult> PatchCard(int id, JsonPatchDocument<UpdateCardRequest> card)
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

        [HttpDelete("listId={id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCards(int id)
        {
            await _cardService.DeleteCardsAsync(id);
            return Ok();
        }
    }
}

