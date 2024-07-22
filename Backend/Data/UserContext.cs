using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class UserContext : IdentityDbContext<IdentityUser>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
    }
}
