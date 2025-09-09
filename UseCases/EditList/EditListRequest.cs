namespace simulado.UseCases.EditList;

public record EditListRequest(
    Guid ListID,
    Guid FicId,
    Guid OwnerID
);