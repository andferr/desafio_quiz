namespace Application.UseCases.DeleteUser;

public sealed record DeleteUserResponse
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
}
