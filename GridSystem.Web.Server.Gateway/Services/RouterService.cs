using Grpc.Net.Client;

namespace GridSystem.Web.Server.Gateway.Services;

public class RouterService
{
    private readonly Auth.AuthClient _authClient;

    public RouterService()
    {
        var authChannel = GrpcChannel.ForAddress("https://localhost:7129");
        _authClient = new Auth.AuthClient(authChannel);
    }
    
    public async Task Execute(WebApplication app)
    {
        
    }
}