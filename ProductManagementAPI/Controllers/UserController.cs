using CRNproduct_management.DTO;
using CRNproduct_management.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            var user = await _userService.RegisterAsync(dto);

            return Ok(new
            {
                Message = "User registered successfully",
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email
            });

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);

            if (result == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid email or password"
                });
            }

            return Ok(new
            {
                Message = "Login successful",
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken
            });
        }
    }
}
