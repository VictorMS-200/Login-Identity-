using AutoMapper;
using Entity.Dto;
using Entity.Models;
using Entity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Entity.controller;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly RegisterService _UserServices;

    public UserController(RegisterService userServices)
    {
        _UserServices = userServices;
    }

    // Method for creating a user
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        await _UserServices.Register(dto);
        return Ok("User created successfully!");
    }

}