using Inventory_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class AsignacionController: Controller
    {
        public IActionResult CrearAsignacion()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CrearAsignacion(Asignaciones asignaciones)
        {
            if (!ModelState.IsValid) 
            { 
                return View(asignaciones); 
            }

            return View();
        }
    }
}
