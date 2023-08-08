using AutoMapper;
using Entity.Dto;
using Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Entity.controller;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    // Creating Indepency Injection for the (mapper and usermanager) 
    private readonly IMapper _mapper;
    private readonly UserManager<User> _usermanager;


    // Creating a constructor for the (mapper and usermanager)
    public UserController(IMapper mapper, UserManager<User> usermanager)
    {
        _mapper = mapper;
        _usermanager = usermanager;
    }


    // Method for creating a user
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        // Mapping the dto to the user
        var user = _mapper.Map<User>(dto);

        // Creating a user with the usermanager and the dto password
        IdentityResult identityResult = await _usermanager.CreateAsync(user, dto.Password);

        // If the user is created return ok
        if (identityResult.Succeeded)
        {
            return Ok("User created!");
        }

        throw new ApplicationException("User creation failed!");
    }

}