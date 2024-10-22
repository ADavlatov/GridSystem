namespace GridSystem.Web.Server.Core.Models;

public record User
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public string Key { get; set; }
    public List<Result> Results { get; set; }
}