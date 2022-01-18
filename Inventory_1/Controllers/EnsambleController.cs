using Dapper;
using Inventory_1.Models;
using Inventory_1.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace Inventory_1.Controllers
{
    public class EnsambleController: Controller
    {
        private readonly IRepositorioEnsamble repositorioEnsamble;

        public EnsambleController(IRepositorioEnsamble repositorioEnsamble)
        {
            this.repositorioEnsamble = repositorioEnsamble;
        }
        public IActionResult CrearEnsamble()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CrearEnsamble(Ensamblajes ensamblajes)
        {
            if (!ModelState.IsValid)
            {
                return View(ensamblajes);
            }

            repositorioEnsamble.CrearEnsamble(ensamblajes);
            return View();
        }
    }
}
