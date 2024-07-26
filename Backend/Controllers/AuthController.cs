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
      
        private readonly IUserRepository _userRepository;

        public AuthController(UserService userService, IUserRepository userRepository)
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
                await _userRepository.CompleteAsync();
               
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
            Console.WriteLine(model.Email);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _userService.Login(model);

            if (token != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddMinutes(30)
                };

                Response.Cookies.Append("jwt", token, cookieOptions);

                //Get users details here
                var data = await _userRepository.FindUsersByEmailAsync(model.Email);
                var userData = data.ToList()[0];

                return Ok(userData);
            }

            return Unauthorized("Invalid username or password.");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            if (Request.Cookies["jwt"] != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, 
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddMinutes(-1)
                };

                Response.Cookies.Append("jwt", "", cookieOptions);
            }

            return Ok("Logout successful.");
        }
    }

}
