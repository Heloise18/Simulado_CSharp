namespace simulado.UseCases.Auth;

public record AuthRequest (
    Guid FanficID,
    string UserName
);