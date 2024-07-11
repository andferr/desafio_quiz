using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest command,
                                                 CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(command.Id, cancellationToken);

        if (user is null) return default;

        user.Name = command.Name;
        user.Username = command.Username;

        _userRepository.Update(user, cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}