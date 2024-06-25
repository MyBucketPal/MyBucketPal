namespace Backend.Model;

public class Plan
{
    public int PlanId { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
  
    public int TypeId { get; set; }
    public Type Type { get; set; } //navigáció, amire az id mutat
  
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Private { get; set; }

    
    public ICollection<PlanDetail> PlanDetails { get; set; }
    
}