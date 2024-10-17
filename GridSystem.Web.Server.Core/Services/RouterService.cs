namespace GridSystem.Web.Server.Core.Services;

public class RouterService(WebApplication app)
{
    public async Task Execute()
    {
        app.MapPost("/api/v1/status", () =>
        {
            
        });
    }
}