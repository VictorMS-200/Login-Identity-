using AutoMapper;
using Entity.Dto;
using Entity.Models;

namespace Entity.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
		  CreateMap<CreateUserDto, User>();
    }
}