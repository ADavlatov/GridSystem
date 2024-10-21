using System.IdentityModel.Tokens.Jwt;
using GridSystem.Web.Server.Auth.Contexts;
using GridSystem.Web.Server.Auth.Models;
using GridSystem.Web.Server.Auth.Services.ValidationMethods;
using Microsoft.EntityFrameworkCore;

namespace GridSystem.Web.Server.Auth.Services.ProtobufMethods
{
    public class SignIn
    {
        public async Task<SignInResponse> AddUser(SignInRequest request, UserContext db)
        {
            var errors = await new UserValidator().ValidateSignInRequest(request, db);
            
            if (errors != "")
            {
                return new SignInResponse
                {
                    IsSucceed = false,
                    Status = 400,
                    Error = errors
                };
            }

            var user = new User
            {
                Username = request.Username, Email = request.Email, Password = request.Password
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            var userFromDb = await db.Users.FirstOrDefaultAsync(x => x.Username == user.Username);

            return new SignInResponse
            {
                IsSucceed = true,
                Status = 200,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(userFromDb.Id.ToString(), 1)),
                RefreshToken =
                    new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(userFromDb.Id.ToString(), 15)),
                UserId = user.Id.ToString()
            };
        }
    }
}