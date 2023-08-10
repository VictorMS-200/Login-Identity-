using System.ComponentModel.DataAnnotations;


namespace Entity.Dto;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public DateTime DateBirth { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }

}