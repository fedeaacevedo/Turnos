using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Especialidad.ToList());
        }

        public IActionResult Edit(int? id)
        {
            //Si el id no existe generamos un error generico
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = _context.Especialidad.Find(id);

            //Si la especialidad no existe o no es indicada por el usuario generamos un error generico
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost] // Esto diferencia el metodo Edit que graba, del edit de vista.
        public IActionResult Edit(int id, [Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if(id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            //Si la informacion que cargamos es correcta, lo actualizamos o lo guardamos
            if(ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        public IActionResult Delete(int? id)
        {
            //si el ID no es valido, not found
            if(id == null)
            {
                return NotFound();
            }

            var especialidad = _context.Especialidad.FirstOrDefault(e => e.IdEspecialidad == id);

            if(especialidad == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var especialidad = _context.Especialidad.Find(id);
            _context.Especialidad.Remove(especialidad);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
