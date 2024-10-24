namespace GridSystem.Web.Server.Core.Models;

public record Result
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public User User { get; set; }
}