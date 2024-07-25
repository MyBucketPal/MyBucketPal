namespace Backend.Model.DTO;

public class UserDto
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool Premium { get; set; }
    public DateTime BirthDate { get; set; }
}