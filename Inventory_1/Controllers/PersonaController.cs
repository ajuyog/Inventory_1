using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IRepositorioPersona repositorioPersona;

        public PersonaController(IRepositorioPersona repositorioPersona)
        {
            this.repositorioPersona = repositorioPersona;
        }

        public async Task<IActionResult> Index()
        {
            var personas = await repositorioPersona.Obtener();

            return View(personas);
        }

        public IActionResult CrearPersona()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CrearPersona(Personas personas)
        {
            if (!ModelState.IsValid)
            {
                return View(personas);
            }

            var yaExistePers = await repositorioPersona.Existe(personas.idPerson);
            
            if (yaExistePers)
            {
                ModelState.AddModelError(nameof(personas.idPerson), $"El usuario {personas.idPerson} ya esta registrado como {personas.firstname} {personas.lastname}");

                return View(personas);
            }

           await repositorioPersona.CrearPersona(personas);

            return View();
        }
        //verificación por javascript de existencia de dato registrado

        

    }
}
