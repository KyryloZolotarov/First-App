using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Web.Server.Data.Dtos;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IListRepository _listRepository;
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public BoardService(IBoardRepository boardRepository, IListRepository listRepository, IHistoryRepository historyRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _boardRepository = boardRepository;
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public async Task<int> AddBoardAsync(AddBoardRequest board)
        {
            var boardId = await _boardRepository.AddBoardAsync(board);
            var record = new RecordRequest();
            record.DateTime = DateTime.UtcNow;
            record.Property = "Board";
            record.UserId = board.UserId;
            record.Event = OperationType.Add;
            record.Destination = board.Title;
            await _historyRepository.AddRecordAsync(record);
            return boardId;
        }

        public async Task DeleteBoardAsync(string userId, DeleteBoardRequest board)
        {
            await _boardRepository.DeleteBoardAsync(board.Id);
            var lists = await _listRepository.GetListsAsync(board.Id);
            foreach (var list in lists.Lists)
            {
                await _listRepository.DeleteListAsync(list.Id);
            }
            var record = new RecordRequest();
            record.DateTime = DateTime.UtcNow;
            record.Property = "Board";
            record.UserId = userId;
            record.Event = OperationType.Remove;
            record.Destination = board.Title;
            await _historyRepository.AddRecordAsync(record);
        }

        public async Task<List<BoardModel>> GetBoardsAsync(string userId)
        {
            var boards = await _boardRepository.GetBoardsAsync(userId);
            var boardsResponse = boards.Select(s => _mapper.Map<BoardModel>(s)).ToList();
            return boardsResponse;
        }

        public async Task PatchBoardAsync(string userId, int id, JsonPatchDocument<UpdateBoardRequest> board)
        {
            await _boardRepository.PatchBoardAsync(id, board);
            var operations = board.Operations;
            var records = new List<RecordRequest>();
            foreach (var op in operations)
            {
                records.Add(new RecordRequest { DateTime = DateTime.UtcNow, Event = op.OperationType, Property = op.path.TrimStart('/'), Destination = (string)op.value, Origin = op.from, UserId = userId });
            }
            await _historyRepository.AddRecordsAsync(records);
        }
    }
}
