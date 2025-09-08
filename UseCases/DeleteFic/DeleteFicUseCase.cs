namespace simulado.UseCases.DeleteFic;

public class DeleteFicUseCase()
{
    public async Task<Result<DeleteFicResponse>> Do(DeleteFicRequest request)
    {
        
        return Result<DeleteFicResponse>.Success(null);
    }
}