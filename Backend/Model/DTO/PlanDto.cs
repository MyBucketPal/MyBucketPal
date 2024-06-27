namespace Backend.Model.DTO;

public class PlanDto
{
    public int PlanId { get; set; }
    public string Title { get; set; }
    public string City { get; set; }
    public int TypeId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Private { get; set; }
}