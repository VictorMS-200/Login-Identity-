using Microsoft.AspNetCore.Identity;

namespace Entity.Models;


public class User : IdentityUser
{
    public DateTime DateBirth { get; set; }
    public User() : base() { } 
}