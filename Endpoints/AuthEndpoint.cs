using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simulado.UseCases.Auth;

namespace simulado.Endpoints;


public static class AuthEndpoint
{
    public static void ConfigureAuthEndpoint(this WebApplication app)
    {
        app.MapPost("login", async (
            HttpContext http,
            [FromBody] AuthRequest request,
            [FromServices] AuthUseCase usecase) =>
        {
            var response = await usecase.Do(request);

            if (!response.IsSuccessfull)
                return Results.BadRequest(response.Reason);


            return Results.Ok(response);

        });

    }
}