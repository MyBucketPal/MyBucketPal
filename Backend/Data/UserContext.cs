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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MyBucketPal;User Id=sa;Password=yourStrong(!)Password;Encrypt=false;");
        }


    }
}
