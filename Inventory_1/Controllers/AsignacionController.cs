using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class AsignacionController: Controller
    {
        public IActionResult CrearAsignacion(IRepositorioAsignacion repositorioAsignacion)
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
