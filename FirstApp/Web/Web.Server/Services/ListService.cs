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

        public async Task<int> AddListAsync(string userId, AddListRequest list)
        {
            var listId = await _listRepository.AddListAsync(list);
            var record = new RecordRequest();
            record.DateTime = DateTime.UtcNow;
            record.Property = "List";
            record.UserId = userId;
            record.Event = OperationType.Add;
            record.Destination = list.Title;
            await _historyRepository.AddRecordAsync(record);
            return listId;
        }

        public async Task DeleteListAsync(string userId, DeleteListRequest list)
        {
            await _listRepository.DeleteListAsync(list.Id);
            var record = new RecordRequest();
            record.DateTime = DateTime.UtcNow;
            record.Property = "List";
            record.UserId = userId;
            record.Event = OperationType.Remove;
            await _historyRepository.AddRecordAsync(record);
        }

        public async Task<BoardListModel> GetListsAsync(int boardId)
        {
            var list = await _listRepository.GetListsAsync(boardId);
            return _mapper.Map<BoardListModel>(list);
        }

        public async Task PatchListAsync(string userId, int id, JsonPatchDocument<UpdateListRequest> list)
        {
            await _listRepository.PatchListAsync(id, list);
            var operations = list.Operations;
            var records = new List<RecordRequest>();
            foreach (var op in operations)
            {
                records.Add(new RecordRequest { DateTime = DateTime.UtcNow, Event = op.OperationType, Property = op.path.TrimStart('/'), Destination = (string)op.value, Origin = op.from, UserId = userId });
            }
            await _historyRepository.AddRecordsAsync(records);
        }
    }
}
