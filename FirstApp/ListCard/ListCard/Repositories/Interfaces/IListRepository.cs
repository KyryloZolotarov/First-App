﻿using ListCard.Data.Requests;
using ListCard.Data.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace ListCard.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task<int> AddListAsync(AddListRequest list);
        Task PatchListAsync(int id, JsonPatchDocument<UpdateListRequest> list);
        Task DeleteListAsync(int id);
        Task<List<ListResponse>> GetListsAsync(int boardId);
    }
}
