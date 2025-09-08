namespace simulado.UseCases.EditList;

public record EditListRequest (
    Guid FanficID,
    string UserName
);