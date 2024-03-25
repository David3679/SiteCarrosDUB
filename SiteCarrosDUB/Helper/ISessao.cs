using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuariosModel usuario);
        void RemoverSessaoUsuarios();

        UsuariosModel BuscarSessaoUsuario();
    }
}
