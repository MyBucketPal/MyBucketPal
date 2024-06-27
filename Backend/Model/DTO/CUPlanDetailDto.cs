namespace Backend.Model.DTO;

public class CUPlanDetailDto
{
    public int PlanId { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsPrivate { get; set; }
}