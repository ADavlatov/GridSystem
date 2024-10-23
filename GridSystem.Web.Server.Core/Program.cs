using GridSystem.Web.Server.Core.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoreContext>();

var app = builder.Build();

app.Run();