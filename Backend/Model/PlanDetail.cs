using System.Text.Json.Serialization;

namespace Backend.Model;

public class PlanDetail
{
    public int DetailId { get; set; }
    
    public int PlanId { get; set; }
    public Plan Plan { get; set; }
    
    
    public DateTime SubscriptionDate { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsPrivate { get; set; }
    
    //
    [JsonIgnore]
    public ICollection<Subscriber> Subscribers { get; set; }
    
}