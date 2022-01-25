using System.ComponentModel.DataAnnotations;

namespace Inventory_1.Models
{
    public class Asignaciones
    {
        [Required]
        [Display(Name ="Ensamble")]
        public int Assembly_idAssembly { get; set; }
        [Required]
        [Display(Name = "Id Funcionario")]
        public string Person_idPerson { get; set; }
    }
}
