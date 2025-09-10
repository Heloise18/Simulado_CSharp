
using System.ComponentModel.DataAnnotations;
using simulado.Entities;
using simulado.Validations;

namespace simulado.Payloads;

public record RegisterFicData
{
    [Required]
    public required string Title { get; init; }

    [NeedLimitChar]
    [Required]
    public required string Text { get; init; }


}

