namespace simulado.UseCases.RegisterFic;

public record RegisterFicRequest (
    Guid FanficID,
    string UserName
);