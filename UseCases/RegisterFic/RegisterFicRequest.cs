using simulado.Entities;

namespace simulado.UseCases.RegisterFic;

public record RegisterFicRequest (
    string Title,
    string Text,
    Guid OwnerID,
    User Owner
);