using Backend.Data;
using Backend.Model;
using Backend.Repository;

namespace Backend.Services.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<User>> FindUsersByEmailAsync(string email)
    {
        return await FindAsync(user => user.Email == email);
    }

    public async Task AddAsync(User entity)
    {
       await Context.AddAsync(entity);
    }

    public async Task<int> CompleteAsync()
    {
        return await Context.SaveChangesAsync();
    }
}