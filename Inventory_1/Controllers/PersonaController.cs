using Microsoft.AspNetCore.Mvc;

namespace Inventory_1.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
