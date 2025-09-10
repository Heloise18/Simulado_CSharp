using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using simulado.Payloads;
using simulado.UseCases.DeleteFicByID;

namespace simulado.Endpoints;


public static class DeleteFicEndpoint
{
    public static void ConfigureDeleteFicEndpoint(this WebApplication app)
    {
        app.MapDelete("deleteFic", async (
            HttpContext http,
            [FromServices] DeleteFicUseCase usecase,
            [FromBody] FicIDData payload) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);

            if (claim is null)
                return Results.Unauthorized();

            var userID = Guid.Parse(claim.Value);

            var request = new DeleteFicRequest(
                payload.FicID,
                userID
            );

            var response = await usecase.Do(request);

            if (!response.IsSuccessfull && response.Reason == "Usuario não encontrado!")
                return Results.Unauthorized();
            else if (!response.IsSuccessfull)
                return Results.BadRequest();
            
            return Results.Ok();
        }).RequireAuthorization();
    }
}