namespace Backend.Model;

public class Subscriber
{
    public int SubscriberId { get; set; }
    
    public int PlanDetailId { get; set; }
    public PlanDetail PlanDetail { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }

    
    
}