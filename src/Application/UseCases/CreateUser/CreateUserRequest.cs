using MediatR;

namespace Application.UseCases.CreateUser
{
    public sealed record CreateUserRequest(
        string Username, string Name) :
         IRequest<CreateUserResponse>;

}
