using System.IdentityModel.Tokens.Jwt;
using GridSystem.Web.Server.Core.Contexts;
using GridSystem.Web.Server.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GridSystem.Web.Server.Core.Services;

public class UserService(CoreContext db)
{
    public async Task<SetStatusResponse> SetStatus(SetStatusRequest request)
    {
        var userId = Guid.Parse(request.UserId);
        var key = Guid.Parse(request.Key);

        var user = await db.Attributes.FirstAsync(x => x.UserId == id);

        if (user.Key != Guid.Parse(securityKey))
        {
            return new SetStatusResponse { IsSucceed = false, Status = 400, Error = "Wrong security token" };
        }

        user.Status = request.Status;
        db.Attributes.Update(user);
        await db.SaveChangesAsync();

        return new SetStatusResponse { IsSucceed = true, Status = 400, Error = "" };
    }

    public async Task<GetAttributesResponse> GetAttributes(GetAttributesRequest request)
    {
        
    }
}