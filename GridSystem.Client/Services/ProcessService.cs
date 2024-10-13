namespace GridSystem.Client.Services;

public static class ProcessService
{
    public static string Launch(byte[] file)
    {
        Thread.Sleep(5000);
        Random rnd = new Random();
        return rnd.Next(0, 100000).ToString();
    }
}