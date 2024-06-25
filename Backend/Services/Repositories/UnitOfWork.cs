using Backend.Data;
using Backend.Model;
using Backend.Repository;
using Type = Backend.Model.Type;

namespace Backend.Services.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public IRepository<User> Users{ get; private set; }
    public IRepository<Plan> Plans { get; private set; }
    public IRepository<PlanDetail> PlanDetails { get; private set; }
    public IRepository<Subscriber> Subscribers { get; private set; }
    public IRepository<Type> Types { get; private set; }
    

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new Repository<User>(_context);
        Plans = new Repository<Plan>(_context);
        PlanDetails = new Repository<PlanDetail>(_context);
        Subscribers = new Repository<Subscriber>(_context);
        Types = new Repository<Type>(_context);
    }
    
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
    //DEPENDENCY INJECTION MÉG NINCS MEGCSINÁLVA!!!!!
}