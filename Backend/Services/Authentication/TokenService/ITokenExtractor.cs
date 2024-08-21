namespace Backend.Services.Authentication.TokenService;

public interface ITokenExtractor
{
    String GetEmailFromToken(String token);
    //can add more funkc. for get info from token - Claims, etc.
}