using System.ComponentModel.DataAnnotations;


namespace Entity.Dto;

public class LoginUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

}