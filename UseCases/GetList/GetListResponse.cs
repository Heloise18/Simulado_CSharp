using simulado.Payloads;

namespace simulado.UseCases.GetList;

public record GetListResponse (
    string Title, 
    Guid ID,
    DateTime LastChange,
    ICollection<FanficData> FicData
    
);