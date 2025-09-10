using Microsoft.AspNetCore.Mvc;
using simulado.Payloads;
using simulado.UseCases.GetList;

namespace simulado.Endpoints;


public static class GetListByTitleEndpoint
{
    public static void ConfigureGetListByTitleEndpoint(this WebApplication app)
    {
        app.MapGet("registerFic", async (
            string title,
            [FromServices] GetListUseCase usecase) =>
        {
            var request = new GetListRequest(title);
            var response = await usecase.Do(request);

            return (response.IsSuccessfull, response.Reason) switch
            {
                (false, "Lista nao encontrada!") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(response.Value)
            };
            
        });
    }
}