using Backend.Model;
using Type = Backend.Model.Type;


namespace Backend.Data;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    protected ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Plan> Plans { get; set; }
    public DbSet<PlanDetail> PlanDetails { get; set; }
    public DbSet<Subscriber> Subscribers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Type> Types { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString( "DefaultConnection"));
    // set at : dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR CONNECTION STRING"
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //primary keys
        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<Subscriber>().HasKey(s => s.SubscriberId);
        modelBuilder.Entity<PlanDetail>().HasKey(b => b.DetailId);
        modelBuilder.Entity<Plan>().HasKey(p => p.PlanId);
        modelBuilder.Entity<Type>().HasKey(e => e.TypeId);
        
        

        //relations
        modelBuilder.Entity<Plan>()
            .HasOne(p => p.Type)
            .WithMany(p => p.Plans)
            .HasForeignKey(p => p.TypeId)
            ;

        modelBuilder.Entity<PlanDetail>()
            .HasOne(p => p.User)
            .WithMany(u => u.PlanDetails)
            .HasForeignKey(pd => pd.UserId)
            ;

        modelBuilder.Entity<PlanDetail>()
            .HasOne(pd => pd.Plan)
            .WithMany(plan => plan.PlanDetails)
            .HasForeignKey(pdetail => pdetail.PlanId)
            ;
        
        modelBuilder.Entity<Subscriber>()
            .HasOne(s => s.User)
            .WithMany(u => u.Subscribers)
            .HasForeignKey(s => s.UserId);

        modelBuilder.Entity<Subscriber>()
            .HasOne(subs => subs.PlanDetail)
            .WithMany(pd => pd.Subscribers)
            .HasForeignKey(subs => subs.PlanDetailId)
            ;
        

    }
}