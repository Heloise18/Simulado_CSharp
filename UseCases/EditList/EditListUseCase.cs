using simulado.Entities;
using simulado.Services.JWT;

namespace simulado.UseCases.EditList;

public class EditListUseCase(FicsDbContext ctx, IJWTService jwt)
{
    public async Task<Result<EditListResponse>> Do(EditListRequest request)
    {
        var user = ctx.Users

        var verified = jwt.


        CreateToken(user );

        return Result<EditListResponse>.Success(null);
    }
}

// var colletion = list.Fanfics
//             .Select(r => new FanficData(
//                 r.Title,
//                 r.Owner.Name
//             )
            
//             ).ToList();