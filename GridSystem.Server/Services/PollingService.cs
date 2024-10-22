namespace GridSystem.Server.Services;

public class PollingService(IHttpClientFactory httpClientFactory) : IHostedService
{
    private bool _isPollingWork = true;
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var httpClient = httpClientFactory.CreateClient();
        while (_isPollingWork)
        {
            Thread.Sleep(1000);
            var response = await httpClient.GetAsync("https://localhost:7213/api/v1/core/status");
        
            Console.WriteLine(response.StatusCode);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _isPollingWork = false;
        
        return Task.CompletedTask;
    }
}