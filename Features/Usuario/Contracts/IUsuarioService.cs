using ParkingUNAH.Features.Usuario.Dtos;

namespace ParkingUNAH.Features.Usuario.Contracts
{
    public interface IUsuarioService
    {
        UsuarioDto? ObtenerUsuario(string username, string password);
    }
}
