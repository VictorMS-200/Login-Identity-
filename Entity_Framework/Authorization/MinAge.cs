using Microsoft.AspNetCore.Authorization;


namespace Entity.Auth;

public class MinAge : IAuthorizationRequirement
{
    public int Age { get; set; }

    public MinAge(int age)
    {
        Age = age;
    }
}