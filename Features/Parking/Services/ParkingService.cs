using Microsoft.EntityFrameworkCore;
using ParkingUNAH.Features.Parking.Contracts;
using ParkingUNAH.Features.Parking.Dtos;
using ParkingUNAH.Infrastructure.ParkingDb;

namespace ParkingUNAH.Features.Parking.Services
{
    public class ParkingService(ParkingDbContext parkingDbContext) : IParkingService
    {
        private readonly ParkingDbContext _parkingDbContext = parkingDbContext;

        public async Task<List<EstacionamientoSectorDto>> ObtenerEstacionamientoPorSector(int sectorId)
        {
            try
            {
                List<EstacionamientoSectorDto> estacionamientoSector =
                await (from e in _parkingDbContext!.Estacionamiento!.AsQueryable()
                       join s in _parkingDbContext!.Sector!.AsQueryable() on e.SectorId equals s.Id
                       where e.EsActivo &&
                       e.SectorId == sectorId
                       select new EstacionamientoSectorDto()
                       {
                           EstacionamientoId = e.Id,
                           Posicion = e.Posicion,
                           EstaOcupado = e.EstaOcupado,
                           DescripcionSector = s.Descripcion,
                           CodigoSector = s.Codigo,
                       }).ToListAsync();

                return estacionamientoSector;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return [];
            }
        }
    }
}
