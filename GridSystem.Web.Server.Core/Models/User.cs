namespace GridSystem.Web.Server.Core.Models;

public record User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid Key { get; set; }
    public int Status { get; set; }
    public List<Result> Results { get; set; }
}