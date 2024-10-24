using System.IdentityModel.Tokens.Jwt;
using System.Text;
using GridSystem.Web.Server.Auth.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GridSystem.Web.Server.Auth.Services.ProtobufMethods;

public class Token(UserContext db)
{
    public async Task<TokenValidationResponse> Validate(TokenValidationRequest request)
    {
        var result = await IsWrongToken(request.AccessToken);

        if (result == "Invalid token.")
        {
            return new TokenValidationResponse { IsSucceed = false, Status = 400, Error = result };
        }

        return new TokenValidationResponse { IsSucceed = true, Status = 200, Error = "" };
    }

    public async Task<RefreshTokenResponse> Get(RefreshTokenRequest request, UserContext db)
    {
        var result = await IsWrongToken(request.RefreshToken);

        if (result == "Invalid token.")
        {
            return new RefreshTokenResponse { IsSucceed = false, Status = 400, Error = result };
        }

        return new RefreshTokenResponse
        {
            IsSucceed = true,
            Status = 200,
            Error = "",
            AccessToken =
                new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(
                    result, 1)),
            RefreshToken =
                new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(result, 180))
        };
    }
    
    //@TODO в дальнейшем поменять на ассиметричную подпись и проверять в гейтвее
    private async Task<string> IsWrongToken(string token)
    {
        var jwtHandler = new JwtSecurityTokenHandler();

        try
        {
            jwtHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = AuthOptions.Issuer,
                ValidAudience = AuthOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
            }, out _);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "Invalid token.";
        }
        
        var userId = jwtHandler.ReadJwtToken(token).Claims.First().Value;
        var user = await db.Users.FirstOrDefaultAsync(x => x.Id == Guid.Parse(userId));
        
        if (user == null)
        {
            return "Invalid token.";
        }

        return user.Id.ToString();
    }
    
    private class AuthOptions
    {
        public const string Issuer = "GridSystem.Auth";

        public const string Audience = "GridSystem.Client";

        const string Key = "mysupersecret_secretkey!123sadgqhANRTFWsfBWDRgtwafasfdfg";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
    }
}