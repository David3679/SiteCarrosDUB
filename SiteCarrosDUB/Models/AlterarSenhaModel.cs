using System.ComponentModel.DataAnnotations;

namespace SiteCarrosDUB.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a senha atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Informe a nova senha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "A nova senha não bate")]
        public string ConfirmarSenha { get; set; }


    }
}
