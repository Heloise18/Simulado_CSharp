namespace simulado.UseCases.Auth;

public record AuthResponse (
    Guid FanficID,
    string UserName
);