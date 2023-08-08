using AutoMapper;
using Entity.Dto;
using Entity.Models;
using Microsoft.AspNetCore.Identity;

namespace Entity.Services;

public class RegisterService
{
    // Creating Indepency Injection for the (mapper and usermanager) 
    private readonly IMapper _mapper;
    private readonly UserManager<User> _usermanager;


    // Creating a constructor for the (mapper and usermanager)
    public RegisterService(UserManager<User> usermanager, IMapper mapper)
    {
        _usermanager = usermanager;
        _mapper = mapper;
    }


    // Method for creating a user
    public async Task Register(CreateUserDto dto)
    {
        // Mapping the dto to the user
        var user = _mapper.Map<User>(dto);

        // Creating a user with the usermanager and the dto password
        IdentityResult identityResult = await _usermanager.CreateAsync(user, dto.Password);

        // If the user is created return ok
        if (!identityResult.Succeeded)
        {
            throw new ApplicationException("User creation failed!");
        }
    }
}