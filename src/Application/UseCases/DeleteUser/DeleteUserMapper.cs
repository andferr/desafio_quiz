using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.DeleteUser;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest, Users>();
        CreateMap<Users, DeleteUserResponse>();
    }
}
