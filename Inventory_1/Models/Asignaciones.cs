using System.ComponentModel.DataAnnotations;

namespace Inventory_1.Models
{
    public class Asignaciones
    {
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Display(Name ="Ensamble")]
        public int Assembly_idAssembly { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio ")]
        [Display(Name = "Usuario")]
        public string Person_idPerson { get; set; }
    }
}
