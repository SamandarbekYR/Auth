using Auth.DTOs.UserDto;
using Auth.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService user)
        {
            _userService = user;
        }
        [Authorize(Roles ="User")]
        [HttpPost]
        public IActionResult Add([FromForm] UserCreateDto userCreateDto)
        {
           return Ok( _userService.Add(userCreateDto));
        }
    }
}
