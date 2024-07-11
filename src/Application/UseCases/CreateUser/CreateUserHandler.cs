using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.CreateUser;

public class CreateUserHandler :
       IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Users>(request);

        user.PasswordHash = "sdasda";
        _userRepository.Create(user, cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}
