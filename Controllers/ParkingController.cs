using Microsoft.AspNetCore.Mvc;

namespace ParkingUNAH.Controllers
{
    public class ParkingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
