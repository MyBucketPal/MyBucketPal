namespace Backend.Model.DTO;

public class CUUserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Premium { get; set; }
    public DateTime BirthDate { get; set; }
}