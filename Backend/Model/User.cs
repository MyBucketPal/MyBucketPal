using System.Text.Json.Serialization;

namespace Backend.Model;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    //public string Password { get; set; }
    //ne felejts el migr�lni
    public string Email { get; set; }
    public bool Premium { get; set; }
    public DateTime BirthDate { get; set; }
    [JsonIgnore]
    //miben van benne - amiben userId-val hivatkoznak
    public ICollection<Subscriber> Subscribers { get; set; }
}