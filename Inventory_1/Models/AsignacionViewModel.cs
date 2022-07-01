using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_1.Models
{
    public class AsignacionViewModel: Asignacion
    {
        public IEnumerable<SelectListItem> Personas { get; set; }
        public IEnumerable<SelectListItem> Ensambles { get; set; }
    }
}
