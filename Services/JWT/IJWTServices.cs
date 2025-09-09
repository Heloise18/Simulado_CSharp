using simulado.Entities;

namespace simulado.Services.JWT;


public interface IJWTService
{
    string CreateToken( User data );
}