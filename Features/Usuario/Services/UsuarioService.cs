using ParkingUNAH.Features.Usuario.Contracts;
using ParkingUNAH.Features.Usuario.Dtos;
using ParkingUNAH.Infrastructure.ParkingDb;

namespace ParkingUNAH.Features.Usuario.Services
{
    public class UsuarioService(ParkingDbContext parkingDbContext) : IUsuarioService
    {
        private readonly ParkingDbContext _parkingDbContext = parkingDbContext;

        public UsuarioDto? ObtenerUsuario(string username, string password)
        {
            var user = _parkingDbContext.Usuarios?
                .Where(x => (x.Username == username && x.Password == password))
                .FirstOrDefault();
            return user == null
                ? null
                : new UsuarioDto 
                {
                    Id = user.Id,
                    Username = user.Username 
                };
        }
    }
}
