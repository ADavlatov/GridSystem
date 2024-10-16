using GridSystem.Client.Services;var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
await new ReceiverService().Perform();
app.Run();