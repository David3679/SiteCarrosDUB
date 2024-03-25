using SiteCarrosDUB.Enuns;
using System.ComponentModel.DataAnnotations;

namespace SiteCarrosDUB.Models
{
    public class UsuariosSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite seu nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite seu login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite seu e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum Perfil { get; set; }
    }
}
