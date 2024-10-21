using System.IdentityModel.Tokens.Jwt;
using FluentValidation;

namespace GridSystem.Web.Server.Gateway.Services.Validators.Auth;

public class RefreshTokenValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenValidator()
    {
        JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();
        RuleFor(x => x.RefreshToken).Must(x => jwt.CanReadToken(x))
            .WithMessage("The token cannot be read").NotEmpty().WithMessage("The field cannot be empty");
    }
}