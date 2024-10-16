namespace GridSystem.Server.Helpers;

public class TestHelper
{
    public void GenerateFiles(int count, string directory)
    {
        var random = new Random();
        string name = "";
        string path = "";
        
        for (int i = 0; i < count; i++)
        {
            name = $"test{i}.txt";
            path = Path.Combine(directory, name);
            
            File.WriteAllText(path, random.Next(1000000).ToString());
        }
    }
}