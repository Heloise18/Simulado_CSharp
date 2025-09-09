using Microsoft.EntityFrameworkCore;
using simulado.Entities;
using simulado.Services.JWT;

namespace simulado.UseCases.Auth;

public class AuthUseCase(
    FicsDbContext ctx,
    IJWTService jwt
)
{
    public async Task<Result<AuthResponse>> Do(AuthRequest request)
    {
        var user = await ctx.Users
            .FirstOrDefaultAsync(u => u.Name == request.UserName);

        if (user is null)
            return Result<AuthResponse>.Fail("Usuario nao encontrado!");

        if (user.Password != request.Password) {
            return Result<AuthResponse>.Fail("Senha incorreta!");
        }

        var jwtCheck = jwt.CreateToken(new User
        {
            ID = user.ID,
            Name = user.Name,
            Email = user.Email

        });
        return Result<AuthResponse>.Success(new AuthResponse(jwtCheck));
    }
}