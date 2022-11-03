using Microsoft.AspNetCore.Mvc;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {

        public EspecialidadController(TurnosContext context)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
