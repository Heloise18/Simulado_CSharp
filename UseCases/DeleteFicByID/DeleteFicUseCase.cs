using simulado.Entities;

namespace simulado.UseCases.DeleteFicByID;

public class DeleteFicUseCase(
    FicsDbContext ctx
)
{
    public async Task<Result<DeleteFicResponse>> Do(DeleteFicRequest request)
    {

        var user = await ctx.Users
            .Include(u => u.Fanfics)
            .FirstOrDefaultAsync(u => u.Name == request.UserName);
        
            return Result<DeleteFicResponse>.Success(null);
    }
}