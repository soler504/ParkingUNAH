using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingUNAH.Features.Parking.Contracts;
using ParkingUNAH.Models;
using System.Diagnostics;

namespace ParkingUNAH.Controllers
{
    [Authorize]
    public class HomeController(IParkingService _parkingService) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var response = await _parkingService.ObtenerEstadisticasPorSector();
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
