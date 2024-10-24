using System.IdentityModel.Tokens.Jwt;
using GridSystem.Web.Server.Auth.Contexts;
using GridSystem.Web.Server.Auth.Services.ValidationMethods;
using Microsoft.EntityFrameworkCore;

namespace GridSystem.Web.Server.Auth.Services.ProtobufMethods
{
    public class LogIn
    {
        public async Task<LogInResponse> Authorize(LogInRequest request, UserContext db)
        {
            var errors = await new UserValidator().ValidateLogInRequest(request, db);

            if (errors != "")
            {
                return new LogInResponse
                {
                    IsSucceed = false,
                    Status = 400,
                    Error = errors
                };
            }

            var user = await db.Users.FirstAsync(x =>
                x.Username == request.Username || x.Email == request.Username);

            return new LogInResponse
            {
                IsSucceed = true,
                Status = 200,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(user.Id.ToString(), 1)),
                RefreshToken =
                    new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(user.Id.ToString(), 4320)),
                UserId = user.Id.ToString()
            };
        }
    }
}