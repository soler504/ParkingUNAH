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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _usuarioService.ObtenerUsuario(model.Username, model.Password);
            if (user != null)
            {
                /*
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                */
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
            return View("Index", model);
        }
    }
}
