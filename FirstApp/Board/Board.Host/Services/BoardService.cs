using AutoMapper;
using Board.Host.Data;
using Board.Host.Data.Entities;
using Board.Host.Models.Dtos;
using Board.Host.Models.Requests;
using Board.Host.Repositories.Interfaces;
using Board.Host.Services.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace Board.Host.Services
{
    public class BoardService : BaseDataService<ApplicationDbContext>, IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        private readonly IMapper _mapper;

        public BoardService(IBoardRepository boardRepository, IMapper mapper, IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _boardRepository = boardRepository;
        }

        public async Task<int> AddBoardAsync(AddBoardRequest board)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var boardToDb = _mapper.Map<BoardEntity>(board);
                return await _boardRepository.AddBoardAsync(boardToDb);
            });
        }

        public async Task DeleteBoardAsync(int boardId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var boardExists = await _boardRepository.GetBoardAsync(boardId);

                if (boardExists == null) throw new BusinessException($"Board with id: {boardId} not found");
                await _boardRepository.DeleteBoardAsync(boardExists);
            });
        }

        public async Task<List<BoardDto>> GetBoardsAsync(string userId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var boards = await _boardRepository.GetBoardsAsync(userId);
                var boardsResponse = boards.Select(s => _mapper.Map<BoardDto>(s)).ToList();
                return (boardsResponse);
            });
        }

        public async Task PatchBoardAsync(int boardId, JsonPatchDocument<UpdateBoardRequest> board)
        {
            await ExecuteSafeAsync(async () =>
            {
                var boardExists = await _boardRepository.GetBoardAsync(boardId);
                if (boardExists == null) throw new BusinessException($"Board with id: {boardId} not found");

                var updateBoardRequest = _mapper.Map<UpdateBoardRequest>(boardExists);

                board.ApplyTo(updateBoardRequest);
                _mapper.Map(updateBoardRequest, boardExists);
                await _boardRepository.UpdateBoardAsync(boardExists);
            });
        }
    }
}
