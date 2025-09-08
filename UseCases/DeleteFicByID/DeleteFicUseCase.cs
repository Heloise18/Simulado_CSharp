namespace simulado.UseCases.DeleteFicByID;

public class DeleteFicUseCase()
{
    public async Task<Result<DeleteFicResponse>> Do(DeleteFicRequest request)
    {
        
        return Result<DeleteFicResponse>.Success(null);
    }
}