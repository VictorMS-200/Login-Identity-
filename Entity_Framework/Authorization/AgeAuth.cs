using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace Entity.Auth;

public class AgeAuth : AuthorizationHandler<MinAge>
{
    // This is the method that will be called when the policy is invoked
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
    {
        // Get the date of birth claim
        var DateOfBirthClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth);

        if (DateOfBirthClaim is null)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        // Convert the date of birth claim to a DateTime object
        var DateOfBirth = Convert.ToDateTime(DateOfBirthClaim.Value);

        var age = DateTime.Today.Year - DateOfBirth.Year;

        if (DateOfBirth > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        return Task.CompletedTask;

    }
}