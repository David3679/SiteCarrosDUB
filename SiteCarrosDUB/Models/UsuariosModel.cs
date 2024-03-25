using SiteCarrosDUB.Enuns;
using SiteCarrosDUB.Helper;
using System.ComponentModel.DataAnnotations;

namespace SiteCarrosDUB.Models
{
    public class UsuariosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite seu nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite seu login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite seu e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o perfil do usuário")]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Digite sua senha")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void NovaSenhaAlterada(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string SenhaHash()
        {
            return Senha = Senha.GerarHash();
        }

        public string NovaSenhaHash()
        {
            string novasenha = Guid.NewGuid().ToString().Substring(0, 8);
            novasenha = Senha.GerarHash();
            return novasenha;
        }
    }
}
