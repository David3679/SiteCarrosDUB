using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.Repositorios
{
    public interface IUsuariosRepositorio
    {
        UsuariosModel ListarPorId(int id);
        UsuariosModel ListarPorEmailELogin(string email, string login);
        UsuariosModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        UsuariosModel ListarPorLogin(string login);
        List<UsuariosModel> BuscarTodos();

        UsuariosModel Adicionar(UsuariosModel usuarios);

        UsuariosModel Atualizar(UsuariosModel usuarios);

        bool Apagar(int id);
    }
}
