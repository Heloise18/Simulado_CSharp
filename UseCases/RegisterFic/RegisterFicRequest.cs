using simulado.Entities;
using simulado.Validations;

namespace simulado.UseCases.RegisterFic;

public record RegisterFicRequest (
    string Title,
    string Text,
    Guid OwnerID
);