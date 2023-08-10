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
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;


    // Creating a constructor for the (mapper and usermanager)
    public RegisterService(
        UserManager<User> usermanager,
        IMapper mapper,
        SignInManager<User> signInManager,
        TokenService tokenService)
    {
        _usermanager = usermanager;
        _mapper = mapper;
        _signInManager = signInManager;
        _tokenService = tokenService;
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

    public async Task<string> LoginAsync(LoginUserDto dto)
    {
        // Singing in the user with SingInManager 
        var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Login failed!");
        }
        
        var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(user);
        
        return token;
    }
}