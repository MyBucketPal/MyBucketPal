namespace Backend.Model;

public class Type
{
    public int TypeId { get; set; }
    public string Description { get; set; }
    
    
    //miben van benne
    public ICollection<Plan> Plans { get; set; }
}