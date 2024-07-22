using Backend.Model.DTO;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.Authentication
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterDTO model)
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
            return result;
        }
    }


}
