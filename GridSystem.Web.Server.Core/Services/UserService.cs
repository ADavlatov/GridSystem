using GridSystem.Web.Server.Core.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GridSystem.Web.Server.Core.Services;

public class UserService(CoreContext db)
{
    public async Task<SetStatusResponse> SetStatus(SetStatusRequest request)
    {
        var userId = Guid.Parse(request.UserId);
        var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            return new SetStatusResponse { IsSucceed = false, Status = 400, Error = "User not found." };
        }
        
        user.Status = request.Status;
        db.Users.Update(user);
        await db.SaveChangesAsync();
        
        return new SetStatusResponse { IsSucceed = true, Status = 200, Error = "" };
    }

    public async Task<GetStatusResponse> GetStatus(GetStatusRequest request)
    {
        var userId = Guid.Parse(request.UserId);
        var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
        {
            return new GetStatusResponse { IsSucceed = false, Status = 400, Error = "User not found." };
        }

        return new GetStatusResponse { IsSucceed = true, Status = 200, Error = "", UserStatus = user.Status };
    }
}