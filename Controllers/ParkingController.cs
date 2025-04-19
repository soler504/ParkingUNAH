using Microsoft.AspNetCore.Mvc;
using ParkingUNAH.Features.Parking.Contracts;

namespace ParkingUNAH.Controllers
{
    [Route("parqueo")]
    public class ParkingController(IParkingService _parkingService) : Controller
    {
        [HttpGet, Route("sector/{sectorId}")]
        public async Task<IActionResult> EstacionamientoSector([FromRoute] int sectorId)
        {
            var estacionamientoPorSector = await _parkingService
                .ObtenerEstacionamientoPorSector(sectorId);

            if (estacionamientoPorSector == null)
            {
                return NotFound();
            }

            return View(estacionamientoPorSector);
        }
    }
}
