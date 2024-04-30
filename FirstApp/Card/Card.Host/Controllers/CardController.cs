using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;
using Card.Host.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Card.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/<CardController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CardDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCards([FromBody] int listId)
        {
            var result = await _cardService.GetCardsAsync(listId);
            return Ok(result);
        }

        // GET api/<CardController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CardDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCard(int id)
        {
            var result = await _cardService.GetCardAsync(id);
            return Ok(result);
        }

        // POST api/<CardController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddCard([FromBody] CardRequest card)
        {
            await _cardService.AddCardAsync(card);
            return Ok();
        }

        // PUT api/<CardController>/5
        [HttpPatch("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCard(int id, [FromBody] CardRequest card)
        {
            await _cardService.UpdateCardAsync(id, card);
            return Ok();
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCard(int id)
        {
            await _cardService.DeleteCardAsync(id);
            return Ok();
        }
    }
}
