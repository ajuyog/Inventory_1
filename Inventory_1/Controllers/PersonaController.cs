using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class PersonaController: Controller
    {
        private readonly IRepositorioPersona repositorioPersona;

        public PersonaController(IRepositorioPersona repositorioPersona)
        {
            this.repositorioPersona = repositorioPersona;
        }

        public async Task<ActionResult> Index()
        {
            var usuarios = await repositorioPersona.Obtener();

            return View(usuarios);
        }

        public IActionResult CrearPersona()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> CrearPersona(Personas personas)
        {
            if (!ModelState.IsValid)
            {
                return View(personas);
            }

            var personaExit = await repositorioPersona.ExistePerson(personas.idPerson);

            if (personaExit)
            {
                ModelState.AddModelError(nameof(personas.idPerson), $"El registro {personas.idPerson} ya existe");

                return View(personaExit);
            }

            await repositorioPersona.CrearPersona(personas);

            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<ActionResult> Editar(string idPerson)
        {
            var persona = await repositorioPersona.ObtenerPersonas(idPerson);

            if (persona is null)
            {
                return RedirectToAction("No Encontrado");
            }

            return View(persona);

        }

        [HttpPost]

        public async Task<ActionResult> Editar(Personas personas)
        {
            await repositorioPersona.Actualizar(personas);

            return RedirectToAction("Index");
        }
    }
}
