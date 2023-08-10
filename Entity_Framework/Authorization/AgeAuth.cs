using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace Entity.Auth;

public class AgeAuth : AuthorizationHandler<MinAge>
{
    // This is the method that will be called when the policy is invoked
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
    {
            var dataNascimentoClaim = context
                .User.FindFirst(claim =>
                claim.Type == ClaimTypes.DateOfBirth);

            if(dataNascimentoClaim is null)
                return Task.CompletedTask;

            var dataNascimento = Convert
                .ToDateTime(dataNascimentoClaim.Value);

            var idadeUsuario =
                DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento >
                DateTime.Today.AddYears(-idadeUsuario))
                idadeUsuario--;

            if (idadeUsuario >= requirement.Age)
                context.Succeed(requirement);

            return Task.CompletedTask;

    }
}