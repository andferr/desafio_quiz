namespace Application.UseCases.UpdateUser;

public sealed record UpdateUserResponse
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
}
