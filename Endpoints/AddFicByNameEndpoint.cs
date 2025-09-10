using System.Security.Claims;
using Azure;
using Microsoft.AspNetCore.Mvc;
using simulado.Entities;
using simulado.Payloads;
using simulado.UseCases.EditList;

namespace simulado.Endpoints;


public static class AddFicByNameEndpoint
{
    public static void ConfigureAddFicByNameEndpoint(this WebApplication app)
    {
        app.MapPut("addFanfic/{ListID}", async (
            Guid ListID,
            HttpContext http,
            [FromBody] FicIDData payload,
            [FromServices] EditListUseCase usecase) =>
            {
                var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);

                if (claim is null)
                    return Results.Unauthorized();

                var userID = Guid.Parse(claim.Value);

                var request = new EditListRequest(
                    ListID,
                    payload.FicID,
                    userID
                );

                var response = await usecase.Do(request);

                if (!response.IsSuccessfull && response.Reason == "ReadList não encontrada!")
                    return Results.NotFound();
                else if (!response.IsSuccessfull && response.Reason == "Acesso negado!")
                {
                    return Results.Forbid();
                }
                else if(!response.IsSuccessfull)
                {
                    return Results.BadRequest();
                }
            

                return Results.Ok();
            }).RequireAuthorization();
    }
}