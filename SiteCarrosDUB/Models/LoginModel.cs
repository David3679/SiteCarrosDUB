using System.ComponentModel.DataAnnotations;

namespace SiteCarrosDUB.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe seu login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe sua senha")]
        public string Senha { get; set; }
    }
}
