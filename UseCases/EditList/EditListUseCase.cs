using simulado.Entities;
using simulado.Services.JWT;

namespace simulado.UseCases.EditList;

public class EditListUseCase(FicsDbContext ctx, IJWTService jwt)
{
    public async Task<Result<EditListResponse>> Do(EditListRequest request)
    {
        var readList = await ctx.ReadLists
            .FirstOrDefaultAsync(rl => rl.ID == request.ListID);

        if (ReadList.OwnerID != request.OwnerData.ID)
            return Result<EditListResponse>.Fail("Acesso negado!");

        if (ReadList is null)
            return  Result<EditListResponse>.Fail("ReadList não encontrada!");


        var fic = readList.Fanfics.GetByID(request.FicId);
        readList.Fanfics.Add(fic);

        await ctx.SaveChangesAsync();
        return Result<EditListResponse>.Success(null);
    }
}
