using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class ListService : IListService
    {
        private readonly IListCardRepository _listRepository;

        public ListService(IListCardRepository listRepository)
        {
            _listRepository = listRepository;
        }
    }
}
