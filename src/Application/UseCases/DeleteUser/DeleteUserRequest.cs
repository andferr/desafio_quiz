using MediatR;

namespace Application.UseCases.DeleteUser;

public sealed record DeleteUserRequest(int Id)
                  : IRequest<DeleteUserResponse>;
