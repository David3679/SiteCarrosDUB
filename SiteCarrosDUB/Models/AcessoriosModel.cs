using System.ComponentModel.DataAnnotations;

namespace SiteCarrosDUB.Models
{
    public class AcessoriosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome da peça")]
        public string NomeDaPeca { get; set; }
        [Required(ErrorMessage = "Informe a marca da peça")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "informe o valor da peça")]
        public double Valor { get; set; }

    }
}
