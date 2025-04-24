using ParkingUNAH.Features.Parking.Dtos;
using ParkingUNAH.Infrastructure.Common.Dtos;
using ParkingUNAH.Infrastructure.ParkingDb.Dtos;
using ParkingUNAH.Infrastructure.ParkingDb.Entities;

namespace ParkingUNAH.Features.Parking.Contracts
{
    public interface IParkingService
    {
        Task<List<EstacionamientoSectorDto>> ObtenerEstacionamientoPorSector(int sectorId);
        Task<ResponseDto<Estacionamiento>> CambiarEstadoEstacionamiento(int estacionamientoId);
        Task<ResponseDto<int>> ObtenerSectorPorCoordenadas(CoordenadasDto coordenadas);
        Task<List<EstadisticasSectorDto>> ObtenerEstadisticasPorSector();
    }
}
