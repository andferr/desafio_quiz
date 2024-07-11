using MediatR;

namespace Application.UseCases.GetAllUser;

public sealed record GetAllUserRequest : 
                   IRequest<List<GetAllUserResponse>>;
