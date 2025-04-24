using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingUNAH.Features.Parking.Contracts;
using ParkingUNAH.Features.Parking.Dtos;

namespace ParkingUNAH.Controllers
{
    [Authorize]
    public class ParkingController(IParkingService _parkingService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> EstacionamientoSector(int? sectorId)
        {
            if (sectorId == 0)
            {
                return NotFound();
            }

            var estacionamientos = await _parkingService
                .ObtenerEstacionamientoPorSector(sectorId ?? 0);

            if (estacionamientos == null)
            {
                return NotFound();
            }

            return View(estacionamientos);
        }

        [HttpPut]
        public async Task<JsonResult> CambiarEstadoEstacionamiento(int estacionamientoId)
        {
            var response = await _parkingService.CambiarEstadoEstacionamiento(estacionamientoId);
            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> RediregirVistaParqueo([FromBody] CoordenadasDto coordenadas)
        {
            var response = await _parkingService.ObtenerSectorPorCoordenadas(coordenadas);
            if (response.Ok)
            {
                response.Message = $"/parking/EstacionamientoSector?sectorId={response.Data}";
                return Json(response);
            }

            return Json(response);
        }
    }
}
