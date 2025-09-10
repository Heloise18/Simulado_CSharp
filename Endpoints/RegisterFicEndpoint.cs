using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using simulado.Payloads;
using simulado.UseCases.DeleteFic;
using simulado.UseCases.RegisterFic;

namespace simulado.Endpoints;


public static class RegisterFicEndpoint
{
    public static void ConfigureRegisterFicEndpoint(this WebApplication app)
    {
        app.MapPost("registerFic", async (
            HttpContext http,
            [FromBody] RegisterFicData payload,
            [FromServices] RegisterFicUseCase usecase) =>
        {

            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userID = Guid.Parse(claim.Value);

            var request = new RegisterFicRequest(
                payload.Title,
                payload.Text,
                userID
            );
            var response = await usecase.Do(request);
            if(!response.IsSuccessfull)
                return Results.BadRequest();
                
            return Results.Ok(response.Value);
        });
    }
}