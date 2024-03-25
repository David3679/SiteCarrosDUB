using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.Repositorios
{
    public interface IAcessoriosRepositorio
    {
        AcessoriosModel ListarPorId(int id);

        List<AcessoriosModel> BuscarTodos();

        AcessoriosModel Adicionar(AcessoriosModel acessorios);

        AcessoriosModel Atualizar(AcessoriosModel acessorios);

        bool Apagar(int id);
    }
}
