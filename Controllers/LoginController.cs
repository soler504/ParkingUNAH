using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ParkingUNAH.Models;
using System.Security.Claims;
using ParkingUNAH.Features.Usuario.Services;
using ParkingUNAH.Features.Usuario.Contracts;

namespace ParkingUNAH.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _usuarioService.ObtenerUsuario(model.Username, model.Password);
            if (user != null)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                };

                var identity = new ClaimsIdentity(claims, "ParkingUNAHAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("ParkingUNAHAuth", principal);
                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Incorrect username or password");
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
