namespace GridSystem.Server.Database;

public record FileModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Bytes { get; set; }
}