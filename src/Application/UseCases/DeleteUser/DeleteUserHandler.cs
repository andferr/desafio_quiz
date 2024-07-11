using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.DeleteUser;

public sealed class DeleteUserHandler :
                    IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request,
                                                 CancellationToken cancellationToken)
    {

        var user = await _userRepository.Get(request.Id, cancellationToken);

        if (user == null) return default;

        _userRepository.Delete(user, cancellationToken);

        return _mapper.Map<DeleteUserResponse>(user);
    }
}
