namespace Backend.Model.DTO;

public class SubscriberDto
{
    public int SubscriberId { get; set; }
    public int PlanDetailId { get; set; }
    public PlanDetail PlanDetail { get; set; }
}