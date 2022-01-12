using System.ComponentModel.DataAnnotations;

namespace Inventory_1.Models
{
    public class Ensamblajes
    {
        public int idAssambly { get; set; }
        [Display(Name ="Elemento")]
        [Range(minimum: 1,int.MaxValue, ErrorMessage ="El campo {0} es obligatorio")]
        public int Element_idElement { get; set; }
        [Display(Name ="Ensamble")]
        [Range(minimum: 1, int.MaxValue, ErrorMessage = "El campo {0} es obligatorio")]
        public int Assembly_idAssembly { get; set; }
        [Display(Name ="No. Serial")]
        public string serialnumber { get; set; }
        [Display(Name ="Codigo Secundario")]
        public string codSecondary { get; set; }

        //nota
    }
}
