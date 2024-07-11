namespace Application.UseCases.CreateUser;

public sealed record CreateUserResponse
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
}
