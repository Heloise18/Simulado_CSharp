using simulado.Entities;
using simulado.UseCases.DeleteFic;

namespace simulado.UseCases.RegisterFic;

public class RegisterFicUseCase(FicsDbContext ctx)
{
    public async Task<Result<RegisterFicResponse>>Do(RegisterFicRequest request)
    {
        var Fic = new Fanfic
        {
            Title = request.Title,
            Text = request.Text,
            OwnerID = request.OwnerID,
            Owner = request.Owner

        };
        ctx.Fanfics.Add(Fic);
        await ctx.SaveChangesAsync();

        var response = new RegisterFicResponse(Fic.ID);
        
        return Result<RegisterFicResponse>.Success(response);
    }
}