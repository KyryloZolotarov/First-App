using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc.Diagnostics;
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

        public async Task AddListAsync(AddListRequest list)
        {
            await _listRepository.AddListAsync(list);
            var record = new RecordRequest();
            record.DateTime = DateTime.UtcNow;
            record.Property = "Title";
            record.UserId = list.UserId;
            record.Event = OperationType.Add;
            record.Destination = list.Title;
            await _historyRepository.AddRecordAsync(record);
        }

        public async Task DeleteListAsync(DeleteListRequest list)
        {
            await _listRepository.DeleteListAsync(list.Id);
            var record = new RecordRequest();
            record.DateTime = DateTime.UtcNow;
            record.Property = "Title";
            record.UserId = list.UserId;
            record.Event = OperationType.Remove;
            await _historyRepository.AddRecordAsync(record);
        }

        public async Task<UserListModel> GetListsAsync(string userId)
        {
            var list = await _listRepository.GetListsAsync(userId);
            return _mapper.Map<UserListModel>(list);
        }

        public async Task PatchListAsync(string userId, int id, JsonPatchDocument<UpdateListRequest> list)
        {
            await _listRepository.PatchListAsync(id, list);
            var operations = list.Operations;
            var records = new List<RecordRequest>();
            foreach (var op in operations)
            {
                records.Add(new RecordRequest { CardId = id, DateTime = DateTime.Now, Event = op.OperationType, Property = op.path, Destination = (string)op.value, Origin = op.from, UserId = userId });
            }
            await _historyRepository.AddRecordsAsync(records);
        }
    }
}
