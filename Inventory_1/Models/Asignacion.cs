using System.ComponentModel.DataAnnotations;

namespace Inventory_1.Models
{
    public class Asignacion
    {
        [Display(Name ="Ensamble No.")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public int Assembly_idAssembly { get; set; }
        [Display(Name ="Funcionario")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Person_idPerson { get; set; }
    }
}
