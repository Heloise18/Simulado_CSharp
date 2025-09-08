namespace simulado.UseCases.Auth;

public class AuthUseCase()
{
    public async Task<Result<AuthResponse>> Do(AuthRequest request)
    {
        
        return Result<AuthResponse>.Success(null);
    }
}