using Grpc.Net.Client;

namespace GridSystem.Client.Services;

public class ReceiverService
{
    private readonly Grid.GridClient _gridClient;

    public ReceiverService()
    {
        //@TODO вынести host в appsettings
        var channel = GrpcChannel.ForAddress("");
        _gridClient = new Grid.GridClient(channel);
    }

    public async Task Perform()
    {
        int state = 0;
        string result = "";

        while (true)
        {
            var response = await GetFile(state, result);

            if (response.Status == "Empty")
            {
                break;
            }

            state = 1;
            result = ProcessService.Launch(response.File.ToByteArray());
        }
    }

    private async Task<FileResponse> GetFile(int state, string result)
    {
        return await _gridClient.SendFileAsync(new FileRequest { State = state, Result = result });
    }
}