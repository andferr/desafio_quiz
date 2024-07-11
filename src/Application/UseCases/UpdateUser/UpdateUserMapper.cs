using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.UpdateUser;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, Users>();
        CreateMap<Users, UpdateUserResponse>();
    }
}
