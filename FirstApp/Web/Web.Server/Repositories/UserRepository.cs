using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Web.Server.Data.Dtos;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;

namespace Web.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public UserRepository(IHttpClientService httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<UserDto> LoginAsync(LoginDto login)
        {
            return await _httpClient.SendAsync<UserDto, LoginDto>($"{_settings.Value.UserUrl}/users/login",
                HttpMethod.Post, login);
        }

        public async Task<UserDto> SignUpAsync(UserRequest user)
        {
            return await _httpClient.SendAsync<UserDto, UserRequest>($"{_settings.Value.UserUrl}/users/signup",
                HttpMethod.Post, user);
        }
    }
}
