using System.ComponentModel.DataAnnotations;

namespace SiteCarrosDUB.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Informe seu login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe seu e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }
    }
}
