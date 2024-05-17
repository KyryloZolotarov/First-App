using Web.Server.Data.Dtos;
using Web.Server.Data.Requests;

namespace Web.Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> LoginAsync(LoginDto login);
        Task<UserDto> SignUpAsync(UserRequest user);
    }
}
