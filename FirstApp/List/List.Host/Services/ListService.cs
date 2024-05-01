using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using List.Host.Data.Entities;
using List.Host.Models.Dtos;
using List.Host.Models.Requests;
using List.Host.Repositories.Interfaces;
using List.Host.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using TestCatalog.Host.Data;

namespace List.Host.Services
{
    public class ListService : BaseDataService<ApplicationDbContext>, IListService
    {
        private readonly IListRepository _listRepository;

        private readonly IMapper _mapper;

        public ListService(IListRepository listRepository, IMapper mapper, IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _listRepository = listRepository;
        }

        public async Task AddListAsync(ListRequest list)
        {
            await ExecuteSafeAsync(async () =>
            {
                var listToDb = _mapper.Map<ListEntity>(list);
                await _listRepository.AddListAsync(listToDb);
            });
        }

        public async Task DeleteListAsync(int listId)
        {
            await ExecuteSafeAsync(async () =>
            {
                var listExists = await ExecuteSafeAsync(async () => await _listRepository.GetListAsync(listId));

                if (listExists == null) throw new BusinessException($"List with id: {listId} not found");
                await _listRepository.DeleteListAsync(listExists);
            });
        }

        public async Task<ListDto> GetListAsync(int listId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var list = await ExecuteSafeAsync(async () => await _listRepository.GetListAsync(listId));
                if (list == null) throw new BusinessException($"List with id: {listId} not found");
                var listResponse = _mapper.Map<ListDto>(list);
                return (listResponse);
            });
        }

        public async Task<List<ListDto>> GetListsAsync(string userId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var lists = await ExecuteSafeAsync(async () => await _listRepository.GetListsAsync(userId));
                var listsResponse = lists.Select(s => _mapper.Map<ListDto>(s)).ToList();
                return (listsResponse);
            });
        }

        public async Task PatchListAsync(int listId, JsonPatchDocument<ListRequest> list)
        {
            await ExecuteSafeAsync(async () =>
            {
                var listExists = _mapper.Map<ListRequest>( await ExecuteSafeAsync(async () => await _listRepository.GetListAsync(listId)));
                if (listExists == null) throw new BusinessException($"List with id: {listId} not found");
                list.ApplyTo(listExists);
                var updateList = _mapper.Map<ListEntity>(listExists);
                updateList.Id = listId;
                await _listRepository.UpdateListAsync(updateList);
            });
        }
    }
}