using GridSystem.Web.Server.Gateway.Services.Validators.Auth;
using Grpc.Net.Client;

namespace GridSystem.Web.Server.Gateway.Services;

public class RouterService
{
    private readonly Auth.AuthClient _authClient;

    public RouterService()
    {
        //@TODO вынести в appsettings
        var authChannel = GrpcChannel.ForAddress("https://localhost:7129");
        _authClient = new Auth.AuthClient(authChannel);
    }

    public async Task Execute(WebApplication app)
    {
        app.MapPost("/api/v1/auth/signIn",
            async (SignInRequest request) =>
            {
                var result = await new SignInValidator().ValidateAsync(request);

                if (!result.IsValid)
                {
                    return new SignInResponse
                        { IsSucceed = false, Status = 400, Error = string.Join(", ", result.Errors) };
                }

                return await _authClient.SignInUserAsync(request);
            });


        app.MapPost("api/v1/auth/logIn",
            async (LogInRequest request) =>
            {
                var result = await new LogInValidator().ValidateAsync(request);

                if (!result.IsValid)
                {
                    return new LogInResponse
                        { IsSucceed = false, Status = 400, Error = string.Join(", ", result.Errors) };
                }

                return await _authClient.LogInUserAsync(request);
            });

        app.MapPost("api/v1/auth/validate",
            async (TokenValidationRequest request) =>
            {
                var result = await new AccessTokenValidator().ValidateAsync(request);

                if (!result.IsValid)
                {
                    return new TokenValidationResponse
                        { IsSucceed = false, Status = 400, Error = string.Join(", ", result.Errors) };
                }

                return await _authClient.ValidateTokenAsync(request);
            });

        app.MapPost("api/v1/auth/refresh",
            async (RefreshTokenRequest request) =>
            {
                var result = await new RefreshTokenValidator().ValidateAsync(request);

                if (!result.IsValid)
                {
                    return new RefreshTokenResponse
                        { IsSucceed = false, Status = 400, Error = string.Join(", ", result.Errors) };
                }

                return await _authClient.GetAccessTokenAsync(request);
            });

        app.MapPost("api/v1/core/results", () =>
        {

        });

        app.MapGet("/api/v1/core/status", () =>
        {
            Console.WriteLine("status");

            return true;
        });
    }
}