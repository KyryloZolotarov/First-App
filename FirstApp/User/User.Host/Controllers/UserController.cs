using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using User.Host.Models.Dtos;
using User.Host.Models.UserRequests;
using User.Host.Services.Interfaces;

namespace User.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUser([FromBody] UserRequest user)
        {
            var result = await _userService.AddUserAsync(user);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] string userId, UserRequest user)
        {
            await _userService.UpdateUserAsync(userId, user);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserAsync([FromBody] string id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest login)
        {
            var user = await _userService.LoginAsynnc(login);
            return Ok(user);
        }
    }
}
