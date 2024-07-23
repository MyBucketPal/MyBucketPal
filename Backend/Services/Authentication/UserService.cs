using Backend.Data;
using Backend.Services.Authentication.TokenService;
using Backend.Model.DTO;
using Microsoft.AspNetCore.Identity;
using Backend.Model;
using Backend.Repository;

namespace Backend.Services.Authentication
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenManager _tokenManager;

        public UserService(UserManager<IdentityUser> userManager, TokenManager tokenManager)
        {
            _userManager = userManager;
            _tokenManager = tokenManager;
           

            
        }

        public async Task<IdentityResult> RegisterUser(RegisterDTO model, string role)
        {
            var today = DateTime.Today;
            var age = today.Year - model.BirthDate.Year;

            if (age < 18)
            {
                var errors = new List<IdentityError>
                {
                    new IdentityError { Description = "User must be at least 18 years old." }
                };

                return IdentityResult.Failed(errors.ToArray());
            }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Email is already taken."
                });
            }

            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,          
            };

            var result = await _userManager.CreateAsync(user, model.Password );
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return result;
        }

        public async Task<string?> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (result)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    return _tokenManager.GenerateToken(user, roles);
                }
            }
            return null;
        }
    }


}
