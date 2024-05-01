using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Server.Services.Interfaces;

namespace Web.Server.Controllers
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
    }
}
