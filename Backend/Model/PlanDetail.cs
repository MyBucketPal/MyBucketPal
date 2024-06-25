namespace Backend.Model;

public class PlanDetail
{
    public int DetailId { get; set; }
   
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int PlanId { get; set; }
    public Plan Plan { get; set; }
    
    
    public DateTime SubscriptionDate { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public bool Completed { get; set; }
    public bool Private { get; set; }
    
    //
    public ICollection<Subscriber> Subscribers { get; set; }
    
}