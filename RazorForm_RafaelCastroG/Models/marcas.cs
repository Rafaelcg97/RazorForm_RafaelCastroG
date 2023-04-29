using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace RazorForm_RafaelCastroG
{
    public class marcas
    {
        [Key]
        [Display(Name ="ID")]
        public int id_marcas { get; set; }
        [Display(Name = "Marca")]
        public string? nombre_marca { get; set; }
        [Display(Name = "Estado")]
        public string? estados { get; set; }
    }
}
