using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class CardService : ICardService
    {
        private readonly IListCardRepository _listCardRepository;

        public CardService(IListCardRepository listCardRepository)
        {
            _listCardRepository = listCardRepository;
        }
    }
}
