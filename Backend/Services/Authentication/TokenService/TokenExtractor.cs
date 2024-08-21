using System.IdentityModel.Tokens.Jwt;

namespace Backend.Services.Authentication.TokenService;

public class TokenExtractor : ITokenExtractor
{
    public String GetEmailFromToken(String token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
        var result =  jsonToken?.Claims.First(claim => claim.Type == "email").Value;
        return result;
    }
    
    
}