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


        public IActionResult CrearPersona()
        {
            return View();
        }

    }
}
