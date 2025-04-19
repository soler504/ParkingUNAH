using ParkingUNAH.Features.Parking.Dtos;

namespace ParkingUNAH.Features.Parking.Contracts
{
    public interface IParkingService
    {
        Task<List<EstacionamientoSectorDto>> ObtenerEstacionamientoPorSector(int sectorId);
    }
}
