namespace Backend.Model.DTO;

public class SubsribersDto
{
    public int SubscriberId { get; set; }
    public int PlanDetailId { get; set; }
    public PlanDetail PlanDetail { get; set; }
}