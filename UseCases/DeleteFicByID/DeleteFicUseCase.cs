using simulado.Entities;

namespace simulado.UseCases.DeleteFicByID;

public class DeleteFicUseCase(
    FicsDbContext ctx
)
{
    public async Task<Result<DeleteFicResponse>> Do(DeleteFicRequest request)
    {

        var Fic = await ctx.Fanfics
            .Include(f => f.Owner)
            .Select(f => f.Owner == request.Owner);

        ctx.Fanfics.DeleteFicByID(Fic);
        
        return Result<DeleteFicResponse>.Success(null);
    }
}