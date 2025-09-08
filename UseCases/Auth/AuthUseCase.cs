using simulado.Entities;

namespace simulado.UseCases.Auth;

public class AuthUseCase(
    FicsDbContext ctx
    // IJWTService jwt
)
{
    public async Task<Result<AuthResponse>> Do(AuthRequest request)
    {
        
        return Result<AuthResponse>.Success(null);
    }
}