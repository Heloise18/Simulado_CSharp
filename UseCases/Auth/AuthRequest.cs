namespace simulado.UseCases.Auth;

public record AuthRequest (
    string UserName,
    string Password
);