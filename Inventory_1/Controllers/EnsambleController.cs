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

        public async Task<IActionResult> Index()
        {
            var ensamblajes = await repositorioEnsamble.Obtener();
            return View(ensamblajes);
        }



        public IActionResult CrearEnsamble()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEnsamble(Ensamblajes ensamblajes)
        {
            if (!ModelState.IsValid)
            {
                return View(ensamblajes);
            }


            await repositorioEnsamble.CrearEnsamble(ensamblajes);

            return RedirectToAction("Index");
        }
    }
}
