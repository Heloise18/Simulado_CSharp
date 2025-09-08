namespace simulado.UseCases.GetList;

public record GetListRequest (
    Guid FanficID,
    string UserName
);