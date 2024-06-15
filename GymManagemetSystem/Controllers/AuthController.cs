using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            var registeredUser = await _userService.RegisterUser(userDto);
            return Ok(registeredUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var userLoginResponse = await _userService.Login(loginDto);
            if (userLoginResponse == null)
                return Unauthorized();

            return Ok(userLoginResponse);
        }
    }
}
