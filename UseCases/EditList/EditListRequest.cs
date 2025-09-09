using simulado.Payloads;

namespace simulado.UseCases.EditList;

public record EditListRequest(
    Guid ListID,
    Guid FicId,
    ICollection<UserData> OwnerData
);