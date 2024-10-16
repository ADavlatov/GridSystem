using GridSystem.Server.Helpers;
using GridSystem.Server.Services;
using AppContext = GridSystem.Server.Database.AppContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppContext>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<QueueService>();

app.Run();