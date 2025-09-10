using Microsoft.EntityFrameworkCore;
using simulado.Entities;
using simulado.Payloads;

namespace simulado.UseCases.GetList;

public class GetListUseCase(
    FicsDbContext ctx
)
{
    public async Task<Result<GetListResponse>> Do(GetListRequest request)
    {
        var list = await ctx.ReadLists
            .Include(rl => rl.Fanfics)
            .ThenInclude(f =>f.Owner)
            .FirstOrDefaultAsync(rl => rl.Title == request.Title);
        if (list is null)
            return Result<GetListResponse>.Fail("Lista não encontrada!");

        var colletion = list.Fanfics
            .Select(r => new FanficData(
                r.Title,
                r.Owner.Name
                )
            ).ToList();

        var response = new GetListResponse(list.Title,list.ID,list.LastChange,colletion);
    
        return Result<GetListResponse>.Success(response);
    }
}