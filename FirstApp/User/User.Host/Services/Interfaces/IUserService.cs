using User.Host.Models.Dtos;
using User.Host.Models.UserRequests;

namespace User.Host.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AddUserAsync(UserRequest user);
        Task UpdateUserAsync(string userId, UserRequest user);
        Task DeleteUserAsync(string userId);
        Task<UserDto> LoginAsynnc(LoginRequest login);
    }
}
