using Web.Server.Data.Requests;
using Web.Server.Models;

namespace Web.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> LoginAsync(LoginModel login);
        Task<UserModel> SignUpAsync(UserRequest user);
    }
}
