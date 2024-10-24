using GridSystem.Web.Server.Core.Contexts;
using Grpc.Core;

namespace GridSystem.Web.Server.Core.Services;

public class CoreService(CoreContext db) : Core.CoreBase
{
    public override async Task<SetStatusResponse> SetStatus(SetStatusRequest request, ServerCallContext context)
    {
        return await new UserService(db).SetStatus(request);
    }

    public override async Task<GetStatusResponse> GetStatus(GetStatusRequest request,
        ServerCallContext context)
    {
        return await new UserService(db).GetStatus(request);
    }
}