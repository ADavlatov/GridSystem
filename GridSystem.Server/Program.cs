using GridSystem.Server.Services;
using AppContext = GridSystem.Server.Database.AppContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppContext>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGet("/", () => { Console.WriteLine("Hello 2");});

app.MapGrpcService<QueueService>();
app.Run();

Console.ReadKey();