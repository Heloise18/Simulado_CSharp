using simulado.UseCases.DeleteFic;

namespace simulado.UseCases.RegisterFic;

public class RegisterFicUseCase()
{
    public async Task<Result<RegisterFicResponse>> Do(RegisterFicRequest request)
    {
        
        return Result<RegisterFicResponse>.Success(null);
    }
}