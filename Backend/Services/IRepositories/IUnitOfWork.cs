using Backend.Model;
using Type = Backend.Model.Type;

namespace Backend.Repository;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Plan> Plans { get; }
    IRepository<PlanDetail> PlanDetails { get; }
    IRepository<Subscriber> Subscribers { get; }
    IRepository<Type> Types { get; }
    Task<int> CompleteAsync();
}