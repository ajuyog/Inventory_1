using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_1.Controllers
{
    public class AsignacionController : Controller
    {
        private readonly IRepositorioAsignacion repositorioAsignacion;
        private readonly IRepositorioEnsamble repositorioEnsamble;
        private readonly IRepositorioPersona repositorioPersona;

        public AsignacionController(IRepositorioAsignacion repositorioAsignacion, IRepositorioEnsamble repositorioEnsamble, IRepositorioPersona repositorioPersona)
        {
            this.repositorioAsignacion = repositorioAsignacion;
            this.repositorioEnsamble = repositorioEnsamble;
            this.repositorioPersona = repositorioPersona;
        }

        [HttpGet]

        public async Task<IActionResult> CrearAsignacion()
        {
            var personas = await repositorioPersona.Obtener();
            var ensambles = await repositorioEnsamble.Obtener();
            var modelo = new AsignacionViewModel();
            modelo.Personas = personas.Select(x => new SelectListItem(x.firstname + ' ' + x.lastname, x.idPerson));
            modelo.Ensambles = ensambles.Select(x => new SelectListItem(x.serialnumber, x.Assembly_idAssembly.ToString()));

            return View(modelo);
        }

        [HttpPost]

        public async Task<IActionResult> CrearAsignacion(Asignacion asignacion)
        {
            if (!ModelState.IsValid)
            {
                return View(asignacion);
            }

            await repositorioAsignacion.CrearAsignacion(asignacion);

            return RedirectToAction("Index");

        }

    }

}
