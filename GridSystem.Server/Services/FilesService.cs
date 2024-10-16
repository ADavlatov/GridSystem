using GridSystem.Server.Database;
using AppContext = GridSystem.Server.Database.AppContext;

namespace GridSystem.Server.Services;

public class FilesService(AppContext db)
{
    public async Task ConvertFilesToBase64AndSave(string filePath)
    {
        string[] files = Directory.GetFiles(filePath, "*.txt");
        
        foreach (string file in files)
        {
            // Чтение содержимого файла в массив байтов
            byte[] byteArray = File.ReadAllBytes(file);
            db.Files.Add(new FileModel { Name = file, Bytes = byteArray });
        }

        db.SaveChanges();
    }
}