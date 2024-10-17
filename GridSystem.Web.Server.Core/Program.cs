using GridSystem.Web.Server.Core.Services;var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
await new RouterService(app).Execute();
app.Run();