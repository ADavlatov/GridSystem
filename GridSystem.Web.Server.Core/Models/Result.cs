namespace GridSystem.Web.Server.Core.Models;

public record Result
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}