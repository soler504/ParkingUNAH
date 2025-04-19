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
            var estacionamientos = await _parkingService
                .ObtenerEstacionamientoPorSector(sectorId);

            if (estacionamientos == null)
            {
                return NotFound();
            }

            return View(estacionamientos);
        }

        [HttpPut, Route("cambiarEstadoEstacionamiento/{estacionamientoId}")]
        public async Task<JsonResult> CambiarEstadoEstacionamiento([FromRoute] int estacionamientoId)
        {
            var response = await _parkingService.CambiarEstadoEstacionamiento(estacionamientoId);
            return Json(response);
        }
    }
}
