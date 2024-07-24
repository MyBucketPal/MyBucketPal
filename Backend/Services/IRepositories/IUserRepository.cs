using Backend.Model;

namespace Backend.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> FindUsersByEmailAsync(string email);
}