namespace simulado.UseCases.GetList;

public class GetListUseCase()
{
    public async Task<Result<GetListResponse>> Do(GetListRequest request)
    {
        
        return Result<GetListResponse>.Success(null);
    }
}