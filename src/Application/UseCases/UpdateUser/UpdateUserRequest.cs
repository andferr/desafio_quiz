using MediatR;

namespace Application.UseCases.UpdateUser;

public sealed record UpdateUserRequest(int Id,
                      string Username, string Name)
                      : IRequest<UpdateUserResponse>;
