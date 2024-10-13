using Google.Protobuf;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using AppContext = GridSystem.Server.Database.AppContext;

namespace GridSystem.Server.Services;

public class QueueService(AppContext db) : Grid.GridBase
{
    public override async Task<FileResponse> SendFile(FileRequest request, ServerCallContext context)
    {
        var filesCount = await db.Files.CountAsync();
        var file = await db.Files.FirstOrDefaultAsync();

        if (file == null)
        {
            return new FileResponse { Status = "Empty" };
        }

        return new FileResponse { File = ByteString.FromBase64(file.Bytes), Status = "Осталось файлов: " + filesCount };
    }
}