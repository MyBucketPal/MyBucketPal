using Backend.Model;
using Type = Backend.Model.Type;
using Microsoft.EntityFrameworkCore;


namespace Backend.Data;

public class ApplicationDbContext : DbContext
{

    public DbSet<Plan> Plans { get; set; }
    public DbSet<PlanDetail> PlanDetails { get; set; }
    public DbSet<Subscriber> Subscribers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Type> Types { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

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