using Microsoft.AspNetCore.Mvc;

namespace WebParking.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Controlador()
        {
            return View();
        }
        public IActionResult Administrador()
        {
            return View();
        }

    }
}
