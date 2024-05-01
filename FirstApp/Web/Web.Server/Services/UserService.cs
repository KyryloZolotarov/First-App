using AutoMapper;
using Web.Server.Data.Dtos;
using Web.Server.Data.Requests;
using Web.Server.Models;
using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserModel> LoginAsync(LoginModel login)
        {
            var loginToDb = _mapper.Map<LoginDto>(login);
            var result = await _userRepository.LoginAsync(loginToDb);
            var user = _mapper.Map<UserModel>(result);
            return user;
        }

        public async Task<UserModel> SignUpAsync(UserRequest user)
        {
            var result = await _userRepository.SignUpAsync(user);
            var resultUser = _mapper.Map<UserModel>(result);
            return resultUser;
        }
    }
}
