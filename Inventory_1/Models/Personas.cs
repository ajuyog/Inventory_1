using System.ComponentModel.DataAnnotations;

namespace Inventory_1.Models
{
    public class Personas
    {
        [Required(ErrorMessage ="El Campo {0} es requerido")]
        [Display(Name ="Identificación")]
        public string idPerson { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name ="Área")]
        public int Area_idArea { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name ="Perfil")]
        public int PersonType_idPersonType { get; set; }
        [Display(Name ="Descripción")]
        public string description { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name ="Nombres")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display (Name ="Apellidos")]
        public string lastname { get; set; }
        [Display (Name ="Código Secundario")]
        public string codeSecundary { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display (Name ="Activo")]
        public bool active { get; set; }
    }
}
