using Backend.Model;
using Backend.Model.DTO;
using Backend.Repository;
using Backend.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IRepository<User> _userRepository;

        public AuthController(UserService userService, IRepository<User> userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterUser(model, "User");

            if (result.Succeeded)
            {
                var user = new User { Username = model.UserName, Email = model.Email, BirthDate = model.BirthDate };

                await _userRepository.AddAsync(user);

                return Ok("User registered successfully.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _userService.Login(model);

            if (token != null)
            {
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }
    }

}
