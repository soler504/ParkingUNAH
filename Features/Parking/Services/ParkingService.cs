using Microsoft.EntityFrameworkCore;
using ParkingUNAH.Features.Parking.Contracts;
using ParkingUNAH.Features.Parking.Dtos;
using ParkingUNAH.Features.Parking.Messages;
using ParkingUNAH.Features.Parking.Queries;
using ParkingUNAH.Infrastructure.Common.Dtos;
using ParkingUNAH.Infrastructure.ParkingDb;
using ParkingUNAH.Infrastructure.ParkingDb.Dtos;
using ParkingUNAH.Infrastructure.ParkingDb.Entities;

namespace ParkingUNAH.Features.Parking.Services
{
    public class ParkingService(ParkingDbContext parkingDbContext) : IParkingService
    {
        private readonly ParkingDbContext _parkingDbContext = parkingDbContext;

        public async Task<List<EstacionamientoSectorDto>> ObtenerEstacionamientoPorSector(int sectorId)
        {
            try
            {
                List<EstacionamientoSectorDto> estacionamientos =
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
                       }).AsNoTracking().ToListAsync();

                return estacionamientos;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return [];
            }
        }

        public async Task<ResponseDto<Estacionamiento>> CambiarEstadoEstacionamiento(int estacionamientoId)
        {
            try
            {
                var estacionamiento = await _parkingDbContext!.Estacionamiento!.AsQueryable()
                    .FirstOrDefaultAsync(x => x.Id == estacionamientoId);

                if (estacionamiento == null)
                {
                    return ResponseDto<Estacionamiento>.Error(string.Format(MessagesParking.MS01, estacionamientoId));
                }

                await _parkingDbContext.Database.BeginTransactionAsync();
                estacionamiento.EstaOcupado = !estacionamiento.EstaOcupado;
                int rowsAffected = await _parkingDbContext.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    await _parkingDbContext.Database.CommitTransactionAsync();
                    return ResponseDto<Estacionamiento>.Success(estacionamiento);
                }

                await _parkingDbContext.Database.RollbackTransactionAsync();
                return ResponseDto<Estacionamiento>.Error(MessagesParking.MS02);
            }
            catch (Exception ex)
            {
                await _parkingDbContext.Database.RollbackTransactionAsync();
                return ResponseDto<Estacionamiento>.Error(ex.Message);
            }
        }

        public async Task<ResponseDto<int>> ObtenerSectorPorCoordenadas(CoordenadasDto coordenadas)
        {
            try
            {
                string query = string.Format(QueryParking.query001, coordenadas.Latitud, coordenadas.Longitud);
                int sectorId = await _parkingDbContext!.Sector!.FromSqlRaw(query).Select(x => x.Id).FirstOrDefaultAsync();

                if (sectorId <= 0)
                {
                    return ResponseDto<int>.Error(MessagesParking.MS03);
                }

                return ResponseDto<int>.Success(sectorId);
            }
            catch (Exception ex)
            {
                return ResponseDto<int>.Error(ex.Message);
            }
        }

        public async Task<List<EstadisticasSectorDto>> ObtenerEstadisticasPorSector()
        {
            try
            {
                string query = QueryParking.query002;
                var sectores = await _parkingDbContext!.EstadisticasSector!.FromSqlRaw(query).ToListAsync();
                return sectores;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return [];
            }
        }
    }
}
