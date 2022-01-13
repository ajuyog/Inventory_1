using Dapper;
using Inventory_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Inventory_1.Controllers
{
    public class EnsambleController: Controller
    {
        private readonly string connectionString;
        public EnsambleController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IActionResult CrearEnsamble()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = connection.Query("SELECT 1").FirstOrDefault();
            }

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
