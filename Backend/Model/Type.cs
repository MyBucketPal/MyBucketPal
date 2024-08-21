using System.Text.Json.Serialization;

namespace Backend.Model;

public class Type
{
    public int TypeId { get; set; }
    public string Description { get; set; }
    
    
    //miben van benne
    [JsonIgnore]
    public ICollection<Plan> Plans { get; set; }
}