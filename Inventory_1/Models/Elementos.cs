using System.ComponentModel.DataAnnotations;

namespace Inventory_1.Models
{
    public class Elementos
    {
        [Display (Name ="Id Elemento")]
        public int idElemento { get; set; }
        [Required(ErrorMessage ="El Campo {0} es requerido")]
        [Display(Name ="Tipo Elemento")]
        public int ElementoType_idElementType { get; set; }
        [Required(ErrorMessage ="El Campo {0} es requerido")]
        [Display (Name ="Elemento")]
        public int Element_idElement { get; set; }
        [Display (Name ="Codígo Secundario")]
        public int codeSecondary { get; set; }
        [Required (ErrorMessage ="El Campo {0} es requerido")]
        [Display(Name ="Descripción")]
        public string description { get; set; }
        [Required(ErrorMessage ="El Campo {0} es requerido")]
        [Display(Name ="Activo")]
        public bool active { get; set; }
    }
}
