using GridSystem.Client.Services;var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => { Console.WriteLine("Hello 1");});
//await new ReceiverService().Perform();
app.Run();