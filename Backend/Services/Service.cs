using Backend.Model;
using Backend.Repository;

namespace Backend.Services;

public class Service
{
    private readonly IUnitOfWork _unitOfWork;

    public Service(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> PremiumUsers()
    {
        return await _unitOfWork.Users.FindAsync(u => u.Premium == true);
    }

    public async Task<IEnumerable<Plan>> PlansByCity(string city)
    {
        return await _unitOfWork.Plans.FindAsync(p => p.City == city);
        //teszt team
        //teszt tomi
    }
}