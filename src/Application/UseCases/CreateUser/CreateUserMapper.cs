using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, Users>();
        CreateMap<Users, CreateUserResponse>();
    }
}
