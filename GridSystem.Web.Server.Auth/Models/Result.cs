namespace GridSystem.Web.Server.Auth.Models;

public record Result
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}