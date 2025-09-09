using simulado.Entities;

namespace simulado.UseCases.DeleteFicByID;

public class DeleteFicUseCase(
    FicsDbContext ctx
)
{
    public async Task<Result<DeleteFicResponse>> Do(DeleteFicRequest request)
    {
        
        return Result<DeleteFicResponse>.Success(null);
    }
}