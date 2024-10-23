using Grpc.Core;

namespace GridSystem.Web.Server.Core.Services;

public class CoreService : Core.CoreBase
{
    public override async Task<SetStatusResponse> SetStatus(SetStatusRequest request, ServerCallContext context)
    {
        return new SetStatusResponse { IsSucceed = true, Status = 200, Error = "" };
    }

    public override async Task<GetAttributesResponse> GetUserAttributes(GetAttributesRequest request,
        ServerCallContext context)
    {
        return new GetAttributesResponse { IsSucceed = true, Status = 200, Error = "", Key = "", UserStatus = 0 };
    }
}