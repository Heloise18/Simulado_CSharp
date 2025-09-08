namespace simulado.UseCases.DeleteFic;

public record DeleteFicRequest (
    Guid FanficID,
    string UserName
);