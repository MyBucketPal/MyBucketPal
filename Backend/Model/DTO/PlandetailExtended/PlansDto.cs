namespace Backend.Model.DTO.PlandetailExtended;

public class PlansDto
{
    public int PlanId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string TypeDescription{ get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Private { get; set; }
}