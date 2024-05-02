using Web.Server.Data.Models;
using Web.Server.Data.Requests;

namespace Web.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> LoginAsync(LoginModel login);
        Task<UserModel> SignUpAsync(UserRequest user);
    }
}
