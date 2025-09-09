using Microsoft.EntityFrameworkCore;
using simulado.Entities;

namespace simulado.UseCases.DeleteFicByID;

public class DeleteFicUseCase(
    FicsDbContext ctx
)
{
    public async Task<Result<DeleteFicResponse>> Do(DeleteFicRequest request)
    {
        var fic = await ctx.Fanfics.FindAsync(request.FanficID);

        if (fic.OwnerID != request.OwnerID)
            return Result<DeleteFicResponse>.Fail("sl cara kkk");

        ctx.Fanfics.Remove(fic);
        await ctx.SaveChangesAsync();
        
        return Result<DeleteFicResponse>.Success(new DeleteFicResponse());
    }
}