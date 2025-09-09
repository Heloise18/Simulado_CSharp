namespace simulado.UseCases.DeleteFicByID;

public record DeleteFicRequest (
    Guid FanficID,
    Guid OwnerID
);