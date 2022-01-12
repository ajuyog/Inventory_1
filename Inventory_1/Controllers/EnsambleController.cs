using Inventory_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class EnsambleController: Controller
    {
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
            return View();
        }
    }
}
