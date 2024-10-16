using System.Text;

namespace GridSystem.Client.Services;

public static class ProcessService
{
    public static string Launch(byte[] file)
    {
        Thread.Sleep(5000);
        Console.WriteLine(Encoding.UTF8.GetString(file));
        Random rnd = new Random();
        return rnd.Next(0, 100000).ToString();
    }
}