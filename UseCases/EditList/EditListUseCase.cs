using Microsoft.EntityFrameworkCore;
using simulado.Entities;
using simulado.Services.JWT;

namespace simulado.UseCases.EditList;

public class EditListUseCase(FicsDbContext ctx)
{
    public async Task<Result<EditListResponse>> Do(EditListRequest request)
    {
        var readList = await ctx.ReadLists
            .FirstOrDefaultAsync(rl => rl.ID == request.ListID);

        if (readList is null)
            return Result<EditListResponse>.Fail("ReadList não encontrada!");

        if (readList.OwnerID != request.OwnerID)
            return Result<EditListResponse>.Fail("Acesso negado!");

        var fic = await ctx.Fanfics.FirstOrDefaultAsync(f => f.ID == request.FicId);
        readList.Fanfics.Add(fic);

        readList.LastChange = DateTime.Now;

        await ctx.SaveChangesAsync();
        return Result<EditListResponse>.Success(new EditListResponse());
    }
}
