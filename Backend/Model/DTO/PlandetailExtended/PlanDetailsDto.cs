namespace Backend.Model.DTO.PlandetailExtended;

public class PlanDetailsDto
{
    public int DetailId { get; set; }
    public PlansDto PlansDto { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsPrivate { get; set; }
}