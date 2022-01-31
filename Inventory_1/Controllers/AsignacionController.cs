using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class AsignacionController: Controller
    {
        private readonly IRepositorioAsignacion repositorioAsignacion;

        public AsignacionController(IRepositorioAsignacion repositorioAsignacion)
        {
            this.repositorioAsignacion = repositorioAsignacion;
        }

        public IActionResult CrearAsignacion()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CrearAsignacion(Asignaciones asignaciones)
        {
            if (!ModelState.IsValid) 
            { 
                return View(asignaciones); 
            }

            await repositorioAsignacion.CrearAsignacion(asignaciones);

            return View();
        }
    }
}
