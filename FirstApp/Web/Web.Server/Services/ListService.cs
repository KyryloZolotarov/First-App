using AutoMapper;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public ListService(IListRepository listRepository, IHistoryRepository historyRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public async Task AddListAsync(ListRequest list)
        {
            await _listRepository.AddListAsync(list);
            var record = new RecordRequest();
            record.DateTime = DateTime.Now;
            record.Event = Enums.Events.Create;
            record.Property = $"{list.Title} list";
            record.UserId = list.UserId;
            await _historyRepository.AddRecordAsync(record);
        }

        public async Task DeleteListAsync(int id)
        {
            await _listRepository.DeleteListAsync(id);
        }

        public async Task<UserListModel> GetListsAsync(string userId)
        {
            var list = await _listRepository.GetListsAsync(userId);
            return _mapper.Map<UserListModel>(list);
        }

        public async Task PatchListAsync(int id, ListRequest list)
        {
            await _listRepository.PatchListAsync(id, list);
        }
    }
}
