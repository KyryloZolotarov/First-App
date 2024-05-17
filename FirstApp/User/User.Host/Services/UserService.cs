using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using TestCatalog.Host.Data;
using User.Host.Data.Entities;
using User.Host.Models.Dtos;
using User.Host.Models.UserRequests;
using User.Host.Repositories.Interfaces;
using User.Host.Services.Interfaces;

namespace User.Host.Services
{
    public class UserService : BaseDataService<ApplicationDbContext>, IUserService
    {
        private readonly IMapper _mapper;

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger)
            : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> AddUserAsync(UserRequest user)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var userAdd = _mapper.Map<UserEntity>(user);

                var result = await _userRepository.AddUserAsync(userAdd);
                var mappedResult = _mapper.Map<UserDto>(result);
                return mappedResult;
            });
        }

        public async Task DeleteUserAsync(string userId)
        {
            var userExists = await ExecuteSafeAsync(async () => await _userRepository.GetUserAsync(userId));

            if (userExists == null) throw new BusinessException($"User with id: {userId} not found");

            await ExecuteSafeAsync(async () => { await _userRepository.DeleteUserAsync(userExists); });
        }

        public async Task<UserDto> LoginAsynnc(LoginRequest login)
        {
            var userExists = await ExecuteSafeAsync(async () => await _userRepository.GetUserByEmailAsync(login.Email));
            if (userExists == null) throw new BusinessException($"User with Email: {login.Email} not found");
            var user = _mapper.Map<UserDto>(userExists);
            return user;
        }

        public async Task UpdateUserAsync(string userId, UserRequest user)
        {
            var userExists = await ExecuteSafeAsync(async () => await _userRepository.GetUserAsync(userId));

            if (userExists == null) throw new BusinessException($"User with id: {userId} not found");

            if (user.FirstName != null) userExists.FirstName = user.FirstName;

            if (user.LastName != null) userExists.LastName = user.LastName;

            if (user.Email != null) userExists.Email = user.Email;

            if (user.Password != null) userExists.Password = user.Password;

            await ExecuteSafeAsync(async () => { await _userRepository.UpdateUserAsync(userExists); });
        }
    }
}
